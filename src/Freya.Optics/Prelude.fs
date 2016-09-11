namespace Freya.Optics

open Aether

// Prelude

// Commonly used functions, particularly around optics and optical utilities
// for composing and modifying optics in to the core HTTP request/response
// state.

// Option

// Utilities and morphisms for Option types, particularly around unsafe
// degenerate optics for situations where it is safe to bypass the type
// system with confidence.

[<RequireQualifiedAccess>]
module Option =

    /// A function Choice -> Option, effectively discarding the second state.

    let ofChoice =
        function | Choice1Of2 x -> Some x
                 | _ -> None

    /// A degenerate isomorphism from an 'a option to an 'a, where a non-Some
    /// value will result in a runtime error. This should only be used as part
    /// of optics where the form of the data can't be proven at compile time
    /// through a change in type, but can be known.

    let unsafe_ : Isomorphism<'a option,'a> =
        Option.get, Some