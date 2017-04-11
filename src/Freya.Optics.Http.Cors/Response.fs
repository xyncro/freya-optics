namespace Freya.Optics.Http.Cors

open Aether.Operators
open Freya.Core
open Freya.Optics
open Freya.Optics.Http
open Freya.Types.Http.Cors

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

        /// A lens from State -> AccessControlAllowCredentials option,
        /// accessing the optional Access-Control-Allow-Credentials header.

        let accessControlAllowCredentials_ =
            value_ "Access-Control-Allow-Credentials" (AccessControlAllowCredentials.tryParse, AccessControlAllowCredentials.format)

        /// A lens from State -> AccessControlAllowHeaders option, accessing
        /// the optional Access-Control-Allow-Headers header.

        let accessControlAllowHeaders_ =
            value_ "Access-Control-Allow-Headers" (AccessControlAllowHeaders.tryParse, AccessControlAllowHeaders.format)

        /// A lens from State -> AccessControlAllowMethods option, accessing
        /// the optional Access-Control-Allow-Methods header.

        let accessControlAllowMethods_ =
            value_ "Access-Control-Allow-Methods" (AccessControlAllowMethods.tryParse, AccessControlAllowMethods.format)

        /// A lens from State -> AccessControlAllowOrigin option, accessing
        /// the optional Access-Control-Allow-Origin header.

        let accessControlAllowOrigin_ =
            value_ "Access-Control-Allow-Origin" (AccessControlAllowOrigin.tryParse, AccessControlAllowOrigin.format)

        /// A lens from State -> AccessControlExposeHeaders option, accessing
        /// the optional Access-Control-Expose-Headers header.

        let accessControlExposeHeaders_ =
            value_ "Access-Control-Expose-Headers" (AccessControlExposeHeaders.tryParse, AccessControlExposeHeaders.format)

        /// A lens from State -> AccessControlMaxAge option, accessing the
        /// optional Access-Control-Max-Age header.

        let accessControlMaxAge_ =
            value_ "Access-Control-Max-Age" (AccessControlMaxAge.tryParse, AccessControlMaxAge.format)