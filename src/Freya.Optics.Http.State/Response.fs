namespace Freya.Optics.Http.Cors

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.State

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
            >-> Option.mapEpimorphism (tryParse >> Option.ofResult, format)

        /// A lens from State -> SetCookie option,
        /// accessing the optional Set-Cookie header.

        let setCookie_ =
            value_ "Set-Cookie" (SetCookie.tryParse, SetCookie.format)
