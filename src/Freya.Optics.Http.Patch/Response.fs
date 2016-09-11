namespace Freya.Optics.Http.Patch

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.Patch

// Response

/// Optics for working with individual elements of the response as part of the
/// Freya state, including access to typed data using the Freya Types libraries
/// where implemented.

[<RequireQualifiedAccess>]
module Response =

    /// Optics for response headers, usually given as lenses from
    /// State -> 'a option, where 'a is a strongly typed representation of an
    /// optional header. Headers may be added and removed by using the common
    /// Freya optic functionality with Option values.

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                Response.header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        /// A lens from State -> AcceptPatch option, accessing the optional
        /// Accept-Patch header.

        let acceptPatch_ =
            value_ "Accept-Patch" (AcceptPatch.tryParse, AcceptPatch.format)