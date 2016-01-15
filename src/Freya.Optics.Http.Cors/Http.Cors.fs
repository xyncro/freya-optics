module Freya.Optics.Http.Cors

open Aether.Operators
open Arachne.Http.Cors
open Freya.Core
open Freya.Optics
open Freya.Optics.Http

(* Request *)

[<RequireQualifiedAccess>]
module Request =

    (* Headers *)

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                Request.header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        let accessControlRequestHeaders_ =
            value_ "Access-Control-Request-Headers" (AccessControlRequestHeaders.tryParse, AccessControlRequestHeaders.format)

        let accessControlRequestMethod_ =
            value_ "Access-Control-Request-Method" (AccessControlRequestMethod.tryParse, AccessControlRequestMethod.format)

        let origin_ =
            value_ "Origin" (Origin.tryParse, Origin.format)

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