namespace Freya.Optics.Http.Cors

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.Cors

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
            >-> Option.mapEpimorphism (tryParse >> Option.ofChoice, format)

        /// A lens from State -> AccessControlRequestHeaders option, accessing
        /// the optional Access-Control-Request-Headers header.

        let accessControlRequestHeaders_ =
            value_ "Access-Control-Request-Headers" (AccessControlRequestHeaders.tryParse, AccessControlRequestHeaders.format)

        /// A lens from State -> AccessControlRequestMethod option, accessing
        /// the optional Access-Control-Request-Method header.

        let accessControlRequestMethod_ =
            value_ "Access-Control-Request-Method" (AccessControlRequestMethod.tryParse, AccessControlRequestMethod.format)

        /// A lens from State -> Origin option, accessing the optional Origin
        /// header.

        let origin_ =
            value_ "Origin" (Origin.tryParse, Origin.format)