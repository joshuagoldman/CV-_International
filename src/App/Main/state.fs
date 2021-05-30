module Main.state

open Main.types
open Sutil
open Sutil.DOM

let init() =
    {
        Main.types.Name = ""
    }, Cmd.none

let update msg model =
    match msg with
    | Main_Msg_Async asyncMsg ->
        let msg =
            asyncMsg
            |> Cmd.OfAsync.result

        model, msg