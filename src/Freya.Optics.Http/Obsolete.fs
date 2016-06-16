namespace Freya.Optics.Http

open System
open Aether.Operators

(* Obsolete

   Backwards compatibility shims to make the 2.x-> 3.x transition
   less painful, providing functionally equivalent options where possible.

   To be removed for 4.x releases. *)

[<AutoOpen>]
module Obsolete =

    let private option_ =
        id, Some

    (* Request *)

    [<RequireQualifiedAccess>]
    module Request =

        [<Obsolete ("Use Request.body_ instead.")>]
        let Body_ =
            Request.body_

        [<Obsolete ("Use Request.headers_ instead.")>]
        let Headers_ =
            Request.headers_

        [<Obsolete ("Use Request.header_ instead.")>]
        let Header_ key =
                Request.header_ key
            >-> option_

        [<Obsolete ("Use Request.method_ instead.")>]
        let Method_ =
            Request.method_

        [<Obsolete ("Use Request.path_ instead.")>]
        let Path_ =
            Request.path_

        [<Obsolete ("Use Request.pathBase_ instead.")>]
        let PathBase_ =
            Request.pathBase_

        [<Obsolete ("Use Request.httpVersion_ instead.")>]
        let HttpVersion_ =
            Request.httpVersion_

        [<Obsolete ("Use Request.scheme_ instead.")>]
        let Scheme_ =
            Request.scheme_

        [<Obsolete ("Use Request.query_ instead.")>]
        let Query_ =
            Request.query_

        (* Headers *)

        [<RequireQualifiedAccess>]
        module Headers =

            [<Obsolete ("Use Request.Headers.accept_ instead.")>]
            let Accept_ =
                    Request.Headers.accept_
                >-> option_

            [<Obsolete ("Use Request.Headers.acceptCharset_ instead.")>]
            let AcceptCharset_ =
                    Request.Headers.acceptCharset_
                >-> option_

            [<Obsolete ("Use Request.Headers.acceptEncoding_ instead.")>]
            let AcceptEncoding_ =
                    Request.Headers.acceptEncoding_
                >-> option_

            [<Obsolete ("Use Request.Headers.acceptLanguage_ instead.")>]
            let AcceptLanguage_ =
                    Request.Headers.acceptLanguage_
                >-> option_

            [<Obsolete ("Use Request.Headers.authorization_ instead.")>]
            let Authorization_ =
                    Request.Headers.authorization_
                >-> option_

            [<Obsolete ("Use Request.Headers.cacheControl_ instead.")>]
            let CacheControl_ =
                    Request.Headers.cacheControl_
                >-> option_

            [<Obsolete ("Use Request.Headers.connection_ instead.")>]
            let Connection_ =
                    Request.Headers.connection_
                >-> option_

            [<Obsolete ("Use Request.Headers.contentEncoding_ instead.")>]
            let ContentEncoding_ =
                    Request.Headers.contentEncoding_
                >-> option_

            [<Obsolete ("Use Request.Headers.contentLanguage_ instead.")>]
            let ContentLanguage_ =
                    Request.Headers.contentLanguage_
                >-> option_

            [<Obsolete ("Use Request.Headers.contentLength_ instead.")>]
            let ContentLength_ =
                    Request.Headers.contentLength_
                >-> option_

            [<Obsolete ("Use Request.Headers.contentLocation_ instead.")>]
            let ContentLocation_ =
                    Request.Headers.contentLocation_
                >-> option_

            [<Obsolete ("Use Request.Headers.contentType_ instead.")>]
            let ContentType_ =
                    Request.Headers.contentType_
                >-> option_

            [<Obsolete ("Use Request.Headers.date_ instead.")>]
            let Date_ =
                    Request.Headers.date_
                >-> option_

            [<Obsolete ("Use Request.Headers.expect_ instead.")>]
            let Expect_ =
                    Request.Headers.expect_
                >-> option_

            [<Obsolete ("Use Request.Headers.from_ instead.")>]
            let From_ =
                    Request.Headers.from_
                >-> option_

            [<Obsolete ("Use Request.Headers.host_ instead.")>]
            let Host_ =
                    Request.Headers.host_
                >-> option_

            [<Obsolete ("Use Request.Headers.ifMatch_ instead.")>]
            let IfMatch_ =
                    Request.Headers.ifMatch_
                >-> option_

            [<Obsolete ("Use Request.Headers.ifModifiedSince_ instead.")>]
            let IfModifiedSince_ =
                    Request.Headers.ifModifiedSince_
                >-> option_

            [<Obsolete ("Use Request.Headers.ifNoneMatch_ instead.")>]
            let IfNoneMatch_ =
                    Request.Headers.ifNoneMatch_
                >-> option_

            [<Obsolete ("Use Request.Headers.ifRange_ instead.")>]
            let IfRange_ =
                    Request.Headers.ifRange_
                >-> option_

            [<Obsolete ("Use Request.Headers.ifUnmodifiedSince_ instead.")>]
            let IfUnmodifiedSince_ =
                    Request.Headers.ifUnmodifiedSince_
                >-> option_

            [<Obsolete ("Use Request.Headers.maxForwards_ instead.")>]
            let MaxForwards_ =
                    Request.Headers.maxForwards_
                >-> option_

            [<Obsolete ("Use Request.Headers.pragma_ instead.")>]
            let Pragma_ =
                    Request.Headers.pragma_
                >-> option_

            [<Obsolete ("Use Request.Headers.proxyAuthorization_ instead.")>]
            let ProxyAuthorization_ =
                    Request.Headers.proxyAuthorization_
                >-> option_

            [<Obsolete ("Use Request.Headers.range_ instead.")>]
            let Range_ =
                    Request.Headers.range_
                >-> option_

            [<Obsolete ("Use Request.Headers.referer_ instead.")>]
            let Referer_ =
                    Request.Headers.referer_
                >-> option_

            [<Obsolete ("Use Request.Headers.te_ instead.")>]
            let TE_ =
                    Request.Headers.te_
                >-> option_

            [<Obsolete ("Use Request.Headers.trailer_ instead.")>]
            let Trailer_ =
                    Request.Headers.trailer_
                >-> option_

            [<Obsolete ("Use Request.Headers.transferEncoding_ instead.")>]
            let TransferEncoding_ =
                    Request.Headers.transferEncoding_
                >-> option_

            [<Obsolete ("Use Request.Headers.upgrade_ instead.")>]
            let Upgrade_ =
                    Request.Headers.upgrade_
                >-> option_

            [<Obsolete ("Use Request.Headers.userAgent_ instead.")>]
            let UserAgent_ =
                    Request.Headers.userAgent_
                >-> option_

            [<Obsolete ("Use Request.Headers.via_ instead.")>]
            let Via_ =
                    Request.Headers.via_
                >-> option_

    (* Response *)

    [<RequireQualifiedAccess>]
    module Response =

        [<Obsolete ("Use Response.body_ instead.")>]
        let Body_ =
            Response.body_

        [<Obsolete ("Use Response.headers_ instead.")>]
        let Headers_ =
            Response.headers_

        [<Obsolete ("Use Response.header_ instead.")>]
        let Header_ key =
                Response.header_ key
            >-> option_

        [<Obsolete ("Use Response.httpVersion_ instead.")>]
        let HttpVersion_ =
                Response.httpVersion_
            >-> option_

        [<Obsolete ("Use Response.reasonPhrase_ instead.")>]
        let ReasonPhrase_ =
                Response.reasonPhrase_
            >-> option_

        [<Obsolete ("Use Response.statusCode_ instead.")>]
        let StatusCode_ =
                Response.statusCode_
            >-> option_

        (* Headers *)

        [<RequireQualifiedAccess>]
        module Headers =

            [<Obsolete ("Use Response.Headers.acceptRanges_ instead.")>]
            let AcceptRanges_ =
                    Response.Headers.acceptRanges_
                >-> option_

            [<Obsolete ("Use Response.Headers.age_ instead.")>]
            let Age_ =
                    Response.Headers.age_
                >-> option_

            [<Obsolete ("Use Response.Headers.allow_ instead.")>]
            let Allow_ =
                    Response.Headers.allow_
                >-> option_

            [<Obsolete ("Use Response.Headers.cacheControl_ instead.")>]
            let CacheControl_ =
                    Response.Headers.cacheControl_
                >-> option_

            [<Obsolete ("Use Response.Headers.connection_ instead.")>]
            let Connection_ =
                    Response.Headers.connection_
                >-> option_

            [<Obsolete ("Use Response.Headers.contentEncoding_ instead.")>]
            let ContentEncoding_ =
                    Response.Headers.contentEncoding_
                >-> option_

            [<Obsolete ("Use Response.Headers.contentLanguage_ instead.")>]
            let ContentLanguage_ =
                    Response.Headers.contentLanguage_
                >-> option_

            [<Obsolete ("Use Response.Headers.contentLength_ instead.")>]
            let ContentLength_ =
                    Response.Headers.contentLength_
                >-> option_

            [<Obsolete ("Use Response.Headers.contentLocation_ instead.")>]
            let ContentLocation_ =
                    Response.Headers.contentLocation_
                >-> option_

            [<Obsolete ("Use Response.Headers.contentRange_ instead.")>]
            let ContentRange_ =
                    Response.Headers.contentRange_
                >-> option_

            [<Obsolete ("Use Response.Headers.contentType_ instead.")>]
            let ContentType_ =
                    Response.Headers.contentType_
                >-> option_

            [<Obsolete ("Use Response.Headers.date_ instead.")>]
            let Date_ =
                    Response.Headers.date_
                >-> option_

            [<Obsolete ("Use Response.Headers.eTag_ instead.")>]
            let ETag_ =
                    Response.Headers.eTag_
                >-> option_

            [<Obsolete ("Use Response.Headers.expires_ instead.")>]
            let Expires_ =
                    Response.Headers.expires_
                >-> option_

            [<Obsolete ("Use Response.Headers.lastModified_ instead.")>]
            let LastModified_ =
                    Response.Headers.lastModified_
                >-> option_

            [<Obsolete ("Use Response.Headers.location_ instead.")>]
            let Location_ =
                    Response.Headers.location_
                >-> option_

            [<Obsolete ("Use Response.Headers.proxyAuthenticate_ instead.")>]
            let ProxyAuthenticate_ =
                    Response.Headers.proxyAuthenticate_
                >-> option_

            [<Obsolete ("Use Response.Headers.retryAfter_ instead.")>]
            let RetryAfter_ =
                    Response.Headers.retryAfter_
                >-> option_

            [<Obsolete ("Use Response.Headers.server_ instead.")>]
            let Server_ =
                    Response.Headers.server_
                >-> option_

            [<Obsolete ("Use Response.Headers.trailer_ instead.")>]
            let Trailer_ =
                    Response.Headers.trailer_
                >-> option_

            [<Obsolete ("Use Response.Headers.transferEncoding_ instead.")>]
            let TransferEncoding_ =
                    Response.Headers.transferEncoding_
                >-> option_

            [<Obsolete ("Use Response.Headers.upgrade_ instead.")>]
            let Upgrade_ =
                    Response.Headers.upgrade_
                >-> option_

            [<Obsolete ("Use Response.Headers.vary_ instead.")>]
            let Vary_ =
                    Response.Headers.vary_
                >-> option_

            [<Obsolete ("Use Response.Headers.warning_ instead.")>]
            let Warning_ =
                    Response.Headers.warning_
                >-> option_

            [<Obsolete ("Use Response.Headers.wwwAuthenticate_ instead.")>]
            let WwwAuthenticate_ =
                    Response.Headers.wwwAuthenticate_
                >-> option_