﻿// Nu Game Engine.
// Copyright (C) Bryan Edds, 2013-2014.

namespace Nu
open System
open OpenTK
open Nu

module Constants =

    let [<Literal>] DefaultGameName = "Game"
    let [<Literal>] DefaultScreenName = "Screen"
    let [<Literal>] DefaultGroupName = "Group"
    let [<Literal>] DefaultEntityName = "Entity"
    let [<Literal>] NameFieldName = "Name"
    let [<Literal>] RootNodeName = "Root"
    let [<Literal>] TypeAttributeName = "type"
    let [<Literal>] DispatcherNameAttributeName = "dispatcherName"
    let [<Literal>] AssetGraphFilePath = "AssetGraph.xml"
    let [<Literal>] OverlayFilePath = "Overlay.xml"
    let [<Literal>] DefaultPackageName = "Default"
    let [<Literal>] IncludeAttributeName = "include"
    let [<Literal>] DefaultImageValue = "Image;Default;AssetGraph.xml"
    let [<Literal>] DefaultTileMapAssetValue = "TileMap;Default;AssetGraph.xml"
    let [<Literal>] DefaultFontValue = "Font;Default;AssetGraph.xml"
    let [<Literal>] DefaultSoundValue = "Sound;Default;AssetGraph.xml"
    let [<Literal>] DefaultSongValue = "Song;Default;AssetGraph.xml"
    let [<Literal>] PackageNodeName = "Package"
    let [<Literal>] AssetNodeName = "Asset"
    let [<Literal>] AssetsNodeName = "Assets"
    let [<Literal>] GroupNodeName = "Group"
    let [<Literal>] EntitiesNodeName = "Entities"
    let [<Literal>] EntityNodeName = "Entity"
    let [<Literal>] NameAttributeName = "name"
    let [<Literal>] FileAttributeName = "file"
    let [<Literal>] DirectoryAttributeName = "directory"
    let [<Literal>] RecursiveAttributeName = "recursive"
    let [<Literal>] ExtensionAttributeName = "extension"
    let [<Literal>] AssociationsAttributeName = "associations"
    let [<Literal>] RenderingAssociation = "Rendering"
    let [<Literal>] AudioAssociation = "Audio"
    let [<Literal>] SuccessReturnCode = 0
    let [<Literal>] FailureReturnCode = 1
    let DesiredFps = 60
    let ScreenClearing = ColorClear (255uy, 255uy, 255uy)
    let PhysicsStepRate = 1.0f / single DesiredFps
    let PhysicsToPixelRatio = 64.0f
    let PixelToPhysicsRatio = 1.0f / PhysicsToPixelRatio
    let AudioFrequency = 44100
    let AudioBufferSizeDefault = 1024
    let NormalDensity = 10.0f // NOTE: this seems to be a stable density for Farseer
    let Gravity = Vector2 (0.0f, -9.80665f) * PhysicsToPixelRatio
    let CollisionProperty = "C"
    let DefaultTimeToFadeOutSongMs = 500
    let RadiansToDegrees = 57.2957795
    let DegreesToRadians = 1.0 / RadiansToDegrees
    let RadiansToDegreesF = single RadiansToDegrees
    let DegreesToRadiansF = single DegreesToRadians
    let DefaultEntitySize = Vector2 64.0f
    let TickEventAddress = !* "Tick"
    let DownEventAddress = !* "Down"
    let UpEventAddress = !* "Up"
    let ClickEventAddress = !* "Click"
    let OnEventAddress = !* "On"
    let OffEventAddress = !* "Off"
    let TouchEventAddress = !* "Touch"
    let ReleaseEventAddress = !* "Release"
    let MouseDragEventAddress = !* "Mouse/Drag"
    let MouseMoveEventAddress = !* "Mouse/Move"
    let MouseLeftEventAddress = !* "Mouse/Left"
    let MouseCenterEventAddress = !* "Mouse/Center"
    let MouseRightEventAddress = !* "Mouse/Right"
    let MouseX1EventAddress = !* "Mouse/X1"
    let MouseX2tEventAddress = !* "Mouse/X2"
    let DownMouseLeftEventAddress = ["Down"] +@ MouseLeftEventAddress
    let DownMouseCenterEventAddress = ["Down"] +@ MouseCenterEventAddress
    let DownMouseRightEventAddress = ["Down"] +@ MouseRightEventAddress
    let UpMouseLeftEventAddress = ["Up"] +@ MouseLeftEventAddress
    let UpMouseCenterEventAddress = ["Up"] +@ MouseCenterEventAddress
    let UpMouseRightEventAddress = ["Up"] +@ MouseRightEventAddress
    let DownMouseEventAddress = !* "Down/Mouse"
    let UpMouseEventAddress = !* "Up/Mouse"
    let DownKeyboardKeyEventAddress = !* "Down/KeyboardKey"
    let UpKeyboardKeyEventAddress = !* "Up/KeyboardKey"
    let AnyEventAddress = !* "*"
    let StartIncomingEventAddress = !* "Start/Incoming"
    let StartOutgoingEventAddress = !* "Start/Outgoing"
    let FinishIncomingEventAddress = !* "Finish/Incoming"
    let FinishOutgoingEventAddress = !* "Finish/Outgoing"
    let SelectEventAddress = !* "Select"
    let DeselectEventAddress = !* "Deselect"
    let CollisionEventAddress = !* "Collision"
    let AddEventAddress = !* "Add"
    let RemovingEventAddress = !* "Removing"
    let ChangeEventAddress = !* "Change"
    let GamePublishingPriority = Single.MaxValue
    let ScreenPublishingPriority = GamePublishingPriority * 0.5f
    let GroupPublishingPriority = ScreenPublishingPriority * 0.5f
    let EntityPublishingPriority = GroupPublishingPriority * 0.5f
    let ResolutionXDefault = 960
    let ResolutionYDefault = 544
    let ResolutionX = Core.getResolutionOrDefault true ResolutionXDefault
    let ResolutionY = Core.getResolutionOrDefault false ResolutionYDefault