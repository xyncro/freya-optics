namespace Freya.Optics.Http.Cors

open System
open Aether.Operators

(* Obsolete

   Backwards compatibility shims to make the 2.x-> 3.x transition
   less painful, providing functionally equivalent options where possible.

   To be removed for 4.x releases. *)

[<AutoOpen>]
module Obsolete =

    let private option_ =
        id, Some

    (* Request *)

    [<RequireQualifiedAccess>]
    module Request =

        (* Headers *)

        [<RequireQualifiedAccess>]
        module Headers =

            [<Obsolete ("Use Request.Headers.accessControlRequestHeaders_ instead.")>]
            let AccessControlRequestHeaders_ =
                    Request.Headers.accessControlRequestHeaders_
                >-> option_

            [<Obsolete ("Use Request.Headers.accessControlRequestMethod_ instead.")>]
            let AccessControlRequestMethod_ =
                    Request.Headers.accessControlRequestMethod_
                >-> option_

            [<Obsolete ("Use Request.Headers.origin_ instead.")>]
            let Origin_ =
                    Request.Headers.origin_
                >-> option_

    (* Response *)

    [<RequireQualifiedAccess>]
    module Response =

        (* Headers *)

        [<RequireQualifiedAccess>]
        module Headers =

            [<Obsolete ("Use Response.Headers.accessControlAllowCredentials_ instead.")>]
            let AccessControlAllowCredentials_ =
                    Response.Headers.accessControlAllowCredentials_
                >-> option_

            [<Obsolete ("Use Response.Headers.accessControlAllowHeaders_ instead.")>]
            let AccessControlAllowHeaders_ =
                    Response.Headers.accessControlAllowHeaders_
                >-> option_

            [<Obsolete ("Use Response.Headers.accessControlAllowMethods_ instead.")>]
            let AccessControlAllowMethods_ =
                    Response.Headers.accessControlAllowMethods_
                >-> option_

            [<Obsolete ("Use Response.Headers.accessControlAllowOrigin_ instead.")>]
            let AccessControlAllowOrigin_ =
                    Response.Headers.accessControlAllowOrigin_
                >-> option_

            [<Obsolete ("Use Response.Headers.accessControlExposeHeaders_ instead.")>]
            let AccessControlExposeHeaders_ =
                    Response.Headers.accessControlExposeHeaders_
                >-> option_

            [<Obsolete ("Use Response.Headers.accessControlMaxAge_ instead.")>]
            let AccessControlMaxAge_ =
                    Response.Headers.accessControlMaxAge_
                >-> option_