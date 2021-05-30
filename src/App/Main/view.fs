module Main.view

open Sutil
open Sutil.DOM
open Sutil.Attr
open Feliz
open Feliz.Styles
open Main.functions.miscellaneous

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

let styleSheet = [
    Sutil.Styling.rule "*" [
        Css.margin 0
        Css.padding 0
        Css.boxSizingBorderBox
        Css.textDecorationNone
    ]
    Sutil.Styling.rule ".max-width" [
        Css.maxWidth (length.px 1300)
        Css.padding (length.px 0,length.px 80)
        Css.margin length.auto
    ]
    Sutil.Styling.rule ".navbar" [
        Css.width (length.percent 100.0)
        Css.padding (length.px 15)
        Css.backgroundColor "crimson"
        Css.fontFamily "sans serif"

    ]
    Sutil.Styling.rule ".navbar .max-width" [
        Css.justifyContentSpaceBetween
        Css.displayFlex
        Css.alignItemsCenter
    ]
    Sutil.Styling.rule ".menu-list a" [
        Css.fontSize (length.px 18)
        Css.fontWeight 500
    ]
    Sutil.Styling.rule ".menu-list a:link" [
        Css.color "#fff"
    ]
    Sutil.Styling.rule ".menu-list a:hover" [
        Css.color "black"
    ]
    Sutil.Styling.rule ".menu-list" [
        Css.marginTop 5
    ]
    Sutil.Styling.rule ".logo" [
        Css.color "#fff"
        Css.fontSize (length.px 35)
        Css.fontWeight 600
    ]
]


let menuLinks = [
    "Home"
    "About"
    "Skills"
    "Teams"
    "Contact"
]

let getMenuLinks name =
    Bulma.Column.column [
        class' "menu-list"
        Html.a [
            Attr.href "#"
            text name
        ]
    ]

let view() = 
    // model is an IStore<ModeL>
    // This means we can write to it if we want, but when we're adopting
    // Elmish, we treat it like an IObservable<Model>
    let model, dispatch = () |> Store.makeElmish Main.state.init Main.state.update ignore

    Html.nav [
        Bulma.Column.column [
            Html.div [
                class' "columns navbar"
                Bulma.Column.isOneFifth [
                    Html.div [
                        class' "logo"
                        Attr.href "#"
                        text "Portfo"
                        Html.span [
                            text "lio."
                        ] 
                    ]
                ]
                Bulma.Column.isOneFifth [
                    style [ Css.marginLeft (length.percent 56.0)]
                    (menuLinks |> List.map getMenuLinks)
                    |> Bulma.Columns.isCentered
                ]
            ]
        ]
    ] |> Sutil.Styling.withStyle styleSheet

