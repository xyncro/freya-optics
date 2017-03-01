namespace Freya.Optics.Http

open System.Collections.Generic
open System.IO
open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Types.Http

// Response

/// Optics for working with individual elements of the response as part of the
/// Freya state, including access to typed data using the Freya Types libraries
/// where implemented.

[<RequireQualifiedAccess>]
module Response =

    /// A lens from State -> Stream, accessing the response body. Care should
    /// be taken to ensure that the stream is managed appropriately when using
    /// the stream outside of a higher level abstraction such as a machine.

    let body_ =
            State.value_<Stream> Constants.ResponseBody
        >-> Option.unsafe_

    /// A lens from State -> IDictionary<string,string []>, accessing the
    /// complete set of response headers. This lens is generally not expected
    /// to be used directly in user code, but as part of composed optics giving
    /// safer usage.

    let headers_ =
            State.value_<IDictionary<string, string []>> Constants.ResponseHeaders
        >-> Option.unsafe_

    /// A lens from State -> string option, given a key, accessing a
    /// possible response header value in raw form.

    let header_ key =
            headers_
        >-> Dict.value_<string, string []> key
        >-> Option.mapIsomorphism ((String.concat ","), (Array.create 1))

    /// A lens from State -> HttpVersion, accessing the response version.

    let httpVersion_ =
            State.value_<string> Constants.ResponseProtocol
        >-> Option.mapIsomorphism (HttpVersion.parse, HttpVersion.format)

    /// A lens from State -> string, accessing the response reason phrase.

    let reasonPhrase_ =
            State.value_<string> Constants.ResponseReasonPhrase

    /// A lens from State -> int, accessing the response status code.

    let statusCode_ =
            State.value_<int> Constants.ResponseStatusCode

    /// Optics for response headers, usually given as lenses from
    /// State -> 'a option, where 'a is a strongly typed representation of an
    /// optional header. Headers may be added and removed by using the common
    /// Freya optic functionality with Option values.

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofResult, format)

        /// A lens from State -> string option, accessing the optional
        /// Accept-Ranges header in a weakly typed form.

        let acceptRanges_ =
            header_ "Accept-Ranges"

        /// A lens from State -> Age option, accessing the optional Age
        /// header.

        let age_ =
            value_ "Age" (Age.tryParse, Age.format)

        /// A lens from State -> Allow option, accessing the optional Allow
        /// header.

        let allow_ =
            value_ "Allow" (Allow.tryParse, Allow.format)

        /// A lens from State -> CacheControl option, accessing the optional
        /// Cache-Control header.

        let cacheControl_ =
            value_ "Cache-Control" (CacheControl.tryParse, CacheControl.format)

        /// A lens from State -> Connection option, accessing the optional
        /// Connection header.

        let connection_ =
            value_ "Connection" (Connection.tryParse, Connection.format)

        /// A lens from State -> ContentEncoding option, accessing the optional
        /// Content-Encoding header.

        let contentEncoding_ =
            value_ "Content-Encoding" (ContentEncoding.tryParse, ContentEncoding.format)

        /// A lens from State -> ContentLanguage option, accessing the optional
        /// Content-Language header.

        let contentLanguage_ =
            value_ "Content-Language" (ContentLanguage.tryParse, ContentLanguage.format)

        /// A lens from State -> ContentLength option, accessing the optional
        /// Content-Length header.

        let contentLength_ =
            value_ "Content-Length" (ContentLength.tryParse, ContentLength.format)

        /// A lens from State -> ContentLocation option, accessing the optional
        /// Content-Location header.

        let contentLocation_ =
            value_ "Content-Location" (ContentLocation.tryParse, ContentLocation.format)

        /// A lens from State -> string option, accessing the optional
        /// Content-Range header in a weakly typed form.

        let contentRange_ =
            header_ "Content-Range"

        /// A lens from State -> ContentType option, accessing the optional
        /// Content-Type header.

        let contentType_ =
            value_ "Content-Type" (ContentType.tryParse, ContentType.format)

        /// A lens from State -> Date option, accessing the optional Date
        /// header.

        let date_ =
            value_ "Date" (Date.tryParse, Date.format)

        /// A lens from State -> ETag option, accessing the optional ETag
        /// header.

        let eTag_ =
            value_ "ETag" (ETag.tryParse, ETag.format)

        /// A lens from State -> Expires option, accessing the optional Expires
        /// header.

        let expires_ =
            value_ "Expires" (Expires.tryParse, Expires.format)

        /// A lens from State -> LastModified option, accessing the optional
        /// Last-Modified header.

        let lastModified_ =
            value_ "Last-Modified" (LastModified.tryParse, LastModified.format)

        /// A lens from State -> Location option, accessing the optional
        /// Location header.

        let location_ =
            value_ "Location" (Location.tryParse, Location.format)

        /// A lens from State -> string option, accessing the optional
        /// Proxy-Authenticate header in a weakly typed form.

        let proxyAuthenticate_ =
            header_ "Proxy-Authenticate"

        /// A lens from State -> RetryAfter option, accessing the optional
        /// Retry-After header.

        let retryAfter_ =
            value_ "Retry-After" (RetryAfter.tryParse, RetryAfter.format)

        /// A lens from State -> string option, accessing the optional
        /// Server header in a weakly typed form.

        let server_ =
            header_ "Server"

        /// A lens from State -> string option, accessing the optional Trailer
        /// header in a weakly typed form.

        let trailer_ =
            header_ "Trailer"

        /// A lens from State -> string option, accessing the optional
        /// Transfer-Encoding header in a weakly typed form.

        let transferEncoding_ =
            header_ "Transfer-Encoding"

        /// A lens from State -> string option, accessing the optional Upgrade
        /// header in a weakly typed form.

        let upgrade_ =
            header_ "Upgrade"

        /// A lens from State -> string option, accessing the optional Vary
        /// header in a weakly typed form.

        let vary_ =
            header_ "Vary"

        /// A lens from State -> string option, accessing the optional Warning
        /// header in a weakly typed form.

        let warning_ =
            header_ "Warning"

        /// A lens from State -> string option, accessing the optional
        /// WWW-Authenticate header in a weakly typed form.

        let wwwAuthenticate_ =
            header_ "WWW-Authenticate"