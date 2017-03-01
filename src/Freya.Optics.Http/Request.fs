namespace Freya.Optics.Http

open System.Collections.Generic
open System.IO
open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Types.Http
open Freya.Types.Uri

// Request

/// Optics for working with individual elements of the request as part of the
/// Freya state, including access to typed data using the Freya Types libraries
/// where implemented.

[<RequireQualifiedAccess>]
module Request =

    /// A lens from State -> Stream, accessing the request body. Care should
    /// be taken to ensure that the stream is managed appropriately when using
    /// the stream outside of a higher level abstraction such as a machine.

    let body_ =
            State.value_<Stream> Constants.RequestBody
        >-> Option.unsafe_

    /// A lens from State -> IDictionary<string,string []>, accessing the
    /// complete set of request headers. This lens is generally not expected to
    /// be used directly in user code, but as part of composed optics giving
    /// safer usage.

    let headers_ =
            State.value_<IDictionary<string,string []>> Constants.RequestHeaders
        >-> Option.unsafe_

    /// A lens from State -> string option, given a key, accessing a
    /// possible request header value in raw form.

    let header_ key =
            headers_
        >-> Dict.value_<string,string []> key
        >-> Option.mapIsomorphism ((String.concat ","), (Array.create 1))

    /// A lens from State -> Method, accessing the request method.

    let method_ = 
            State.value_<string> Constants.RequestMethod
        >-> Option.unsafe_
        >-> (Method.parse, Method.format)

    /// A lens from State -> string, accessing the request path as defined
    /// by the OWIN specification.

    let path_ =
            State.value_<string> Constants.RequestPath
        >-> Option.unsafe_

    /// A lens from State -> string, accessing the request path base as
    /// defined by the OWIN specification.

    let pathBase_ =
            State.value_<string> Constants.RequestPathBase
        >-> Option.unsafe_

    /// A lens from State -> HttpVersion, accessing the request version.

    let httpVersion_ =
            State.value_<string> Constants.RequestProtocol
        >-> Option.unsafe_
        >-> (HttpVersion.parse, HttpVersion.format)

    /// A lens from State -> Scheme, accessing the request scheme.

    let scheme_ =
            State.value_<string> Constants.RequestScheme
        >-> Option.unsafe_
        >-> (Scheme.parse, Scheme.format)

    /// A lens from State -> Query, accessing the request query.

    let query_ =
            State.value_<string> Constants.RequestQueryString
        >-> Option.unsafe_
        >-> (Query.parse, Query.format)

    /// Optics for request headers, usually given as lenses from
    /// State -> 'a option, where 'a is a strongly typed representation of an
    /// optional header. Headers may be added and removed by using the common
    /// Freya optic functionality with Option values.

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofResult, format)

        /// A lens from State -> Accept option, accessing the optional Accept
        /// header.

        let accept_ =
            value_ "Accept" (Accept.tryParse, Accept.format)

        /// A lens from State -> AcceptCharset option, accessing the optional
        /// Accept-Charset header.

        let acceptCharset_ =
            value_ "Accept-Charset" (AcceptCharset.tryParse, AcceptCharset.format)

        /// A lens from State -> AcceptEncoding option, accessing the optional
        /// Accept-Encoding header.

        let acceptEncoding_ =
            value_ "Accept-Encoding" (AcceptEncoding.tryParse, AcceptEncoding.format)

        /// A lens from State -> AcceptLanguage option, accessing the optional
        /// Accept-Language header.

        let acceptLanguage_ =
            value_ "Accept-Language" (AcceptLanguage.tryParse, AcceptLanguage.format)

        /// A lens from State -> string option, accessing the optional
        /// Authorization header in a weakly typed form.

        let authorization_ =
            header_ "Authorization"

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

        /// A lens from State -> ContentType option, accessing the optional
        /// Content-Type header.

        let contentType_ =
            value_ "Content-Type" (ContentType.tryParse, ContentType.format)

        /// A lens from State -> Date option, accessing the optional Date
        /// header.

        let date_ =
            value_ "Date" (Date.tryParse, Date.format)

        /// A lens from State -> Expect option, accessing the optional Expect
        /// header.

        let expect_ =
            value_ "Expect" (Expect.tryParse, Expect.format)

        /// A lens from State -> string option, accessing the optional From
        /// header in a weakly typed form.

        let from_ =
            header_ "From"

        /// A lens from State -> Host option, accessing the optional Host
        /// header.

        let host_ =
            value_ "Host" (Host.tryParse, Host.format)

        /// A lens from State -> IfMatch option, accessing the optional
        /// If-Match header.

        let ifMatch_ =
            value_ "If-Match" (IfMatch.tryParse, IfMatch.format)

        /// A lens from State -> IfModifiedSince option, accessing the optional
        /// If-Modified-Since header.

        let ifModifiedSince_ =
            value_ "If-Modified-Since" (IfModifiedSince.tryParse, IfModifiedSince.format)

        /// A lens from State -> IfNoneMatch option, accessing the optional
        /// If-None-Match header.

        let ifNoneMatch_ =
            value_ "If-None-Match" (IfNoneMatch.tryParse, IfNoneMatch.format)

        /// A lens from State -> IfRange option, accessing the optional
        /// If-Range header.

        let ifRange_ =
            value_ "If-Range" (IfRange.tryParse, IfRange.format)

        /// A lens from State -> IfUnmodifiedSince option, accessing the optional
        /// If-Unmodified-Since header.

        let ifUnmodifiedSince_ =
            value_ "If-Unmodified-Since" (IfUnmodifiedSince.tryParse, IfUnmodifiedSince.format)

        /// A lens from State -> MaxForwards option, accessing the optional
        /// Max-Forwards header.

        let maxForwards_ =
            value_ "Max-Forwards" (MaxForwards.tryParse, MaxForwards.format)

        /// A lens from State -> string option, accessing the optional Pragma
        /// header in a weakly typed form.

        let pragma_ =
            header_ "Pragma"

        /// A lens from State -> string option, accessing the optional
        /// Proxy-Authorization header in a weakly typed form.

        let proxyAuthorization_ =
            header_ "Proxy-Authorization"

        /// A lens from State -> string option, accessing the optional Range
        /// header in a weakly typed form.

        let range_ =
            header_ "Range"

        /// A lens from State -> string option, accessing the optional
        /// Referrer header.

        let referer_ =
            value_ "Referer" (Referer.tryParse, Referer.format)

        /// A lens from State -> string option, accessing the optional TE
        /// header in a weakly typed form.

        let te_ =
            header_ "TE"

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

        /// A lens from State -> string option, accessing the optional
        /// User-Agent header in a weakly typed form.

        let userAgent_ =
            header_ "User-Agent"

        /// A lens from State -> string option, accessing the optional Via
        /// header in a weakly typed form.

        let via_ =
            header_ "Via"