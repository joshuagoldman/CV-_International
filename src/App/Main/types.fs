module Main.types

open Sutil
open Sutil.DOM
open Sutil.Attr

module Bulma =
    type Column =
        static member column x =
            Html.div (x @ [class' "column"])
        static member isOneThird x =
            Html.div (x @ [class' "column is-one-third"])
        static member isTwoThirds x =
            Html.div (x @ [class' "column is-two-thirds"])
        static member isOneQuarter x =
            Html.div (x @ [class' "column is-one-quarter"])
        static member isTwoQuarters x = 
            Html.div (x @ [class' "column is-two-quarters"])
        static member isThreeQuarters x =
            Html.div (x @ [class' "column is-three-quarters"])
        static member isHalf x = 
            Html.div (x @ [class' "column is-half"])
        static member isOneFifth x = 
            Html.div (x @ [class' "column is-one-fifth"]) 
        static member isTwoFifths x =
            Html.div (x @ [class' "column is-two-fifths"]) 
        static member isThreeFifths x =
            Html.div (x @ [class' "column is-three-fifths"])
        static member isFourFifths x =
            Html.div (x @ [class' "column is-four-fifths"])

    type Columns =
        static member columns x = 
            Html.div (x @ [class' "columns"]) 
        static member isCentered x =
            Html.div (x @ [class' "columns is-centered"])  

type Msg =
    | Main_Msg_Async of Async<Msg>

type Model = {
    Name: string
}

