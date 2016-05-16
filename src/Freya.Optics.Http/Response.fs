namespace Freya.Optics.Http

open System.Collections.Generic
open System.IO
open Aether.Operators
open Arachne.Http
open Freya.Core
open Freya.Optics

(* Response *)

[<RequireQualifiedAccess>]
module Response =

    let body_ =
            State.value_<Stream> Constants.ResponseBody
        >-> Option.unsafe_

    let headers_ =
            State.value_<IDictionary<string, string []>> Constants.ResponseHeaders
        >-> Option.unsafe_

    let header_ key =
            headers_
        >-> Dict.value_<string, string []> key
        >-> Option.mapIsomorphism ((String.concat ","), (Array.create 1))

    let httpVersion_ =
            State.value_<string> Constants.ResponseProtocol
        >-> Option.mapIsomorphism (HttpVersion.parse, HttpVersion.format)

    let reasonPhrase_ =
            State.value_<string> Constants.ResponseReasonPhrase

    let statusCode_ =
            State.value_<int> Constants.ResponseStatusCode

    (* Headers *)

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        let acceptRanges_ =
            header_ "Accept-Ranges"

        let age_ =
            value_ "Age" (Age.tryParse, Age.format)

        let allow_ =
            value_ "Allow" (Allow.tryParse, Allow.format)

        let cacheControl_ =
            value_ "Cache-Control" (CacheControl.tryParse, CacheControl.format)

        let connection_ =
            value_ "Connection" (Connection.tryParse, Connection.format)

        let contentEncoding_ =
            value_ "Content-Encoding" (ContentEncoding.tryParse, ContentEncoding.format)

        let contentLanguage_ =
            value_ "Content-Language" (ContentLanguage.tryParse, ContentLanguage.format)

        let contentLength_ =
            value_ "Content-Length" (ContentLength.tryParse, ContentLength.format)

        let contentLocation_ =
            value_ "Content-Location" (ContentLocation.tryParse, ContentLocation.format)

        let contentRange_ =
            header_ "Content-Range"

        let contentType_ =
            value_ "Content-Type" (ContentType.tryParse, ContentType.format)

        let date_ =
            value_ "Date" (Date.tryParse, Date.format)

        let eTag_ =
            value_ "ETag" (ETag.tryParse, ETag.format)

        let expires_ =
            value_ "Expires" (Expires.tryParse, Expires.format)

        let lastModified_ =
            value_ "Last-Modified" (LastModified.tryParse, LastModified.format)

        let location_ =
            value_ "Location" (Location.tryParse, Location.format)

        let proxyAuthenticate_ =
            header_ "Proxy-Authenticate"

        let retryAfter_ =
            value_ "Retry-After" (RetryAfter.tryParse, RetryAfter.format)

        let server_ =
            header_ "Server"

        let trailer_ =
            header_ "Trailer"

        let transferEncoding_ =
            header_ "Transfer-Encoding"

        let upgrade_ =
            header_ "Upgrade"

        let vary_ =
            header_ "Vary"

        let warning_ =
            header_ "Warning"

        let wwwAuthenticate_ =
            header_ "WWW-Authenticate"