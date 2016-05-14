namespace Freya.Optics.Http

open System.Collections.Generic
open System.IO
open Aether.Operators
open Arachne.Http
open Arachne.Uri
open Freya.Core
open Freya.Optics

(* Request *)

[<RequireQualifiedAccess>]
module Request =

    let body_ =
            Freya.State.value_<Stream> Constants.RequestBody
        >-> Option.unsafe_

    let headers_ =
            Freya.State.value_<IDictionary<string,string []>> Constants.RequestHeaders
        >-> Option.unsafe_

    let header_ key =
            headers_
        >-> Dict.value_<string,string []> key
        >-> Option.mapIsomorphism ((String.concat ","), (Array.create 1))

    let method_ = 
            Freya.State.value_<string> Constants.RequestMethod
        >-> Option.unsafe_
        >-> (Method.parse, Method.format)

    let path_ =
            Freya.State.value_<string> Constants.RequestPath
        >-> Option.unsafe_

    let pathBase_ =
            Freya.State.value_<string> Constants.RequestPathBase
        >-> Option.unsafe_

    let httpVersion_ =
            Freya.State.value_<string> Constants.RequestProtocol
        >-> Option.unsafe_
        >-> (HttpVersion.parse, HttpVersion.format)

    let scheme_ =
            Freya.State.value_<string> Constants.RequestScheme
        >-> Option.unsafe_
        >-> (Scheme.parse, Scheme.format)

    let query_ =
            Freya.State.value_<string> Constants.RequestQueryString
        >-> Option.unsafe_
        >-> (Query.parse, Query.format)

    (* Headers *)

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        let accept_ =
            value_ "Accept" (Accept.tryParse, Accept.format)

        let acceptCharset_ =
            value_ "Accept-Charset" (AcceptCharset.tryParse, AcceptCharset.format)

        let acceptEncoding_ =
            value_ "Accept-Encoding" (AcceptEncoding.tryParse, AcceptEncoding.format)

        let acceptLanguage_ =
            value_ "Accept-Language" (AcceptLanguage.tryParse, AcceptLanguage.format)

        let authorization_ =
            header_ "Authorization"

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

        let contentType_ =
            value_ "Content-Type" (ContentType.tryParse, ContentType.format)

        let date_ =
            value_ "Date" (Date.tryParse, Date.format)

        let expect_ =
            value_ "Expect" (Expect.tryParse, Expect.format)

        let from_ =
            header_ "From"

        let host_ =
            value_ "Host" (Host.tryParse, Host.format)

        let ifMatch_ =
            value_ "If-Match" (IfMatch.tryParse, IfMatch.format)

        let ifModifiedSince_ =
            value_ "If-Modified-Since" (IfModifiedSince.tryParse, IfModifiedSince.format)

        let ifNoneMatch_ =
            value_ "If-None-Match" (IfNoneMatch.tryParse, IfNoneMatch.format)

        let ifRange_ =
            value_ "If-Range" (IfRange.tryParse, IfRange.format)

        let ifUnmodifiedSince_ =
            value_ "If-Unmodified-Since" (IfUnmodifiedSince.tryParse, IfUnmodifiedSince.format)

        let maxForwards_ =
            value_ "Max-Forwards" (MaxForwards.tryParse, MaxForwards.format)

        let pragma_ =
            header_ "Pragma"

        let proxyAuthorization_ =
            header_ "Proxy-Authorization"

        let range_ =
            header_ "Range"

        let referer_ =
            value_ "Referer" (Referer.tryParse, Referer.format)

        let te_ =
            header_ "TE"

        let trailer_ =
            header_ "Trailer"

        let transferEncoding_ =
            header_ "Transfer-Encoding"

        let upgrade_ =
            header_ "Upgrade"

        let userAgent_ =
            header_ "User-Agent"

        let via_ =
            header_ "Via"

