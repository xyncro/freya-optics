namespace Freya.Optics.Http.Cors

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.Cors

(* Response *)

[<RequireQualifiedAccess>]
module Response =

    (* Headers *)

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                Response.header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        let accessControlAllowCredentials_ =
            value_ "Access-Control-Allow-Credentials" (AccessControlAllowCredentials.tryParse, AccessControlAllowCredentials.format)

        let accessControlAllowHeaders_ =
            value_ "Access-Control-Allow-Headers" (AccessControlAllowHeaders.tryParse, AccessControlAllowHeaders.format)

        let accessControlAllowMethods_ =
            value_ "Access-Control-Allow-Methods" (AccessControlAllowMethods.tryParse, AccessControlAllowMethods.format)

        let accessControlAllowOrigin_ =
            value_ "Access-Control-Allow-Origin" (AccessControlAllowOrigin.tryParse, AccessControlAllowOrigin.format)

        let accessControlExposeHeaders_ =
            value_ "Access-Control-Expose-Headers" (AccessControlExposeHeaders.tryParse, AccessControlExposeHeaders.format)

        let accessControlMaxAge_ =
            value_ "Access-Control-Max-Age" (AccessControlMaxAge.tryParse, AccessControlMaxAge.format)