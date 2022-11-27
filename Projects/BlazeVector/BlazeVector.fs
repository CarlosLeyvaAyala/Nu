﻿namespace BlazeVector
open Prime
open Nu
open Nu.Declarative

[<AutoOpen>]
module BlazeVector =

    // this is our Elm-style model type. It determines what state the game is in. To learn about the
    // Elm-style in Nu, see here - https://vsyncronicity.com/2020/03/01/a-game-engine-in-the-elm-style/
    type Model =
        | Splash
        | Title
        | Credits
        | Gameplay of Gameplay

    // this is our Elm-style message type. It provides a signal to show the various screens.
    type Message =
        | ShowTitle
        | ShowCredits
        | ShowGameplay
        | Update
        interface Prime.Message

    // this is our Elm-style command type. Commands are used instead of messages when explicitly
    // updating the world is involved.
    type Command =
        | Exit
        interface Prime.Command

    // this extends the Game API to expose the above model.
    type Game with
        member this.GetModel world = this.GetModelGeneric<Model> world
        member this.SetModel value world = this.SetModelGeneric<Model> value world
        member this.Model = this.ModelGeneric<Model> ()

    // this is the game dispatcher that is customized for our game. In here, we create screens as
    // content and bind them up with events and properties.
    type BlazeVectorDispatcher () =
        inherit GameDispatcher<Model, Message, Command> (Splash)

        // here we define the game's properties and event handling
        override this.Initialize (model, _) =
            [Game.DesiredScreen :=
                match model with
                | Splash -> Desire Simulants.Splash.Screen
                | Title -> Desire Simulants.Title.Screen
                | Credits -> Desire Simulants.Credits.Screen
                | Gameplay gameplay -> match gameplay with Playing -> Desire Simulants.Gameplay.Screen | Quitting | Quit -> Desire Simulants.Title.Screen
             Game.UpdateEvent => Update
             match model with Gameplay gameplay -> Simulants.Gameplay.Screen.Gameplay := gameplay | _ -> ()
             Simulants.Splash.Screen.DeselectingEvent => ShowTitle
             Simulants.Title.Gui.Credits.ClickEvent => ShowCredits
             Simulants.Title.Gui.Play.ClickEvent => ShowGameplay
             Simulants.Title.Gui.Exit.ClickEvent => Exit
             Simulants.Credits.Gui.Back.ClickEvent => ShowTitle]

        // here we handle the above messages
        override this.Message (model, message, _, world) =
            match message with
            | ShowTitle -> just Title
            | ShowCredits -> just Credits
            | ShowGameplay -> just (Gameplay Playing)
            | Update ->
                match model with
                | Gameplay gameplay ->
                    let gameplay' = Simulants.Gameplay.Screen.GetGameplay world
                    if gameplay =/= gameplay' then just (Gameplay gameplay') else just model
                | _ -> just model

        // here we handle the above commands
        override this.Command (_, command, _, world) =
            match command with
            | Exit -> just (World.exit world)

        // here we describe the content of the game, including all of its screens.
        override this.Content (_, _) =
            [Content.screen Simulants.Splash.Screen.Name (Slide (Constants.Dissolve.Default, Constants.Slide.Default, None, Simulants.Title.Screen)) [] []
             Content.screenWithGroupFromFile Simulants.Title.Screen.Name (Dissolve (Constants.Dissolve.Default, Some Assets.Gui.MachinerySong)) Assets.Gui.TitleGroupFilePath [] []
             Content.screenWithGroupFromFile Simulants.Credits.Screen.Name (Dissolve (Constants.Dissolve.Default, Some Assets.Gui.MachinerySong)) Assets.Gui.CreditsGroupFilePath [] []
             Content.screen<GameplayDispatcher> Simulants.Gameplay.Screen.Name (Dissolve (Constants.Dissolve.Default, Some Assets.Gameplay.DeadBlazeSong)) [] []]