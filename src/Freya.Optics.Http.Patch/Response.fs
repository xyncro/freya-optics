namespace Freya.Optics.Http.Patch

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.Patch

(* Response *)

[<RequireQualifiedAccess>]
module Response =

    (* Headers *)

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                Response.header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        let acceptPatch_ =
            value_ "Accept-Patch" (AcceptPatch.tryParse, AcceptPatch.format)