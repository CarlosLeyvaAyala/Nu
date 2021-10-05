﻿// Nu Game Engine.
// Copyright (C) Bryan Edds, 2013-2020.

namespace OmniBlade
open Nu
open OmniBlade

type OmniPlugin () =
    inherit NuPlugin ()
    override this.GetGameDispatcher () = typeof<OmniBladeDispatcher>
    override this.GetEditorScreenDispatcher () = (Simulants.Field.Screen, typeof<DebugFieldDispatcher>)
    override this.MakeOverlayRoutes () =
        [(typeof<ButtonDispatcher>.Name, Some "ButtonDispatcherRoute")
         (typeof<TextDispatcher>.Name, Some "TextDispatcherRoute")
         (typeof<ToggleDispatcher>.Name, Some "ToggleDispatcherRoute")]