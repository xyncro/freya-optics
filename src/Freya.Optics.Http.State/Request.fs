namespace Freya.Optics.Http.Cors

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.State

// Request

/// Optics for working with individual elements of the request as part of the
/// Freya state, including access to typed data using the Freya Types libraries
/// where implemented.

[<RequireQualifiedAccess>]
module Request =

    /// Optics for request headers, usually given as lenses from
    /// State -> 'a option, where 'a is a strongly typed representation of an
    /// optional header. Headers may be added and removed by using the common
    /// Freya optic functionality with Option values.

    [<RequireQualifiedAccess>]
    module Headers =

        let private value_ key (tryParse, format) =
                Request.header_ key
            >-> Option.mapEpimorphism (tryParse >> Option.ofResult, format)

        /// A lens from State -> Cookie option, accessing
        /// the optional Cookie header.

        let cookie_ =
            value_ "Cookie" (Cookie.tryParse, Cookie.format)

