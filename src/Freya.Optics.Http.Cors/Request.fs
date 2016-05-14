namespace Freya.Optics.Http.Cors

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