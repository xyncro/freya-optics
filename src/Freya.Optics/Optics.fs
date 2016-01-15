module Freya.Optics

open Aether

(* Prelude

   Commonly used functions, particularly around optics and optical utilities
   for composing and modifying optics in to the core HTTP request/response
   state. *)

[<AutoOpen>]
module Prelude =

    (* Option

       Utilities and morphisms for Option types, particularly around unsafe
       degenerate optics for situations where it is safe to bypass the type
       system with confidence. *)

    [<RequireQualifiedAccess>]
    module Option =

        let ofChoice =
            function | Choice1Of2 x -> Some x
                     | _ -> None

        let unsafe_ : Isomorphism<'a option,'a> =
            Option.get, Some