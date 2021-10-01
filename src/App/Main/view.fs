module Main.view

open Sutil
open Sutil.DOM
open Sutil.Attr
open Feliz
open Feliz.Styles
open Main.functions.miscellaneous
open Main.types

let styleSheet = [
    Sutil.Styling.rule ".cv-img" [
        Css.height 175
        Css.width 250  
        Css.borderStyleSolid
        Css.marginLeft 5
        Css.borderWidth 2
    ]
    Sutil.Styling.rule ".glass" [
        Css.borderRadius 10
        Css.padding 10
        Css.color color.black
        Css.fontWeightBold
        Css.boxShadow "0 0 1rem 0 rgba(0, 0, 0, 0.4)"
        Css.backgroundColor "rgba(220,243,255, 0.60)"
    ]
    Sutil.Styling.rule ".background" [
        Css.backgroundPosition "no-repeat center center fixed"
        Css.height 1100
        Css.backgroundSize "cover"
        Css.padding (length.px 15)
        Css.backgroundColor "crimson"
        Css.fontFamily "sans serif"
        Css.zIndex -1
        Css.backgroundImage "linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url(cv_background.jpg)"

    ]
    Sutil.Styling.rule "a:hover" [
        Css.color "white"
    ]
    Sutil.Styling.rule "a" [
        Css.color "black"
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

    Bulma.Columns.isCentered [
        class' "background"
        Bulma.Column.isOneFifth [
            
            basicInfos
            |> List.map getBasicInfo
            |> List.append [class' "glass"]
            |> List.append initialBasicInfo
            |> Bulma.Column.column

            proudOf
            |> List.map getStrengths
            |> List.append [getSectionHeader "Proud of"]
            |> List.append [class' "glass"]
            |> Bulma.Column.column
        
        ]
        Bulma.Column.column [
            Bulma.Columns.columns [
                Bulma.Column.column [
                    workInfos
                    |> List.map getEducationInfos
                    |> List.append [getSectionHeader "Work Experience"]
                    |> List.append [class' "glass"]
                    |> Bulma.Column.column
                ]
            ]

            Bulma.Columns.columns [
                Bulma.Column.column [
                    otherSkills
                    |> List.sortByDescending (fun itm -> itm.Percent)
                    |> List.map getSkillLevel
                    |> List.append [getSectionHeader "Skills"]
                    |> List.append [class' "glass"]
                    |> List.append [style [ Css.padding 40]]
                    |> Bulma.Column.column
                ]
            ]
        
        ]
        Bulma.Column.isOneThird [
            Bulma.Columns.columns [
                Bulma.Column.column [
                    educationInfos
                    |> List.map getEducationInfos
                    |> List.append [getSectionHeader "Education"]
                    |> List.append [class' "glass"]
                    |> Bulma.Column.column
                ]
            ]
            Bulma.Columns.columns [
                Bulma.Column.column [
                    languageSkilllevells
                    |> List.map getSkillLevel
                    |> List.append [getSectionHeader "Languages"]
                    |> List.append [class' "glass"]
                    |> List.append [style [ Css.padding 40]]
                    |> Bulma.Column.column
                ]
            ]

            Bulma.Columns.columns [
                Bulma.Column.column [
                    strengths
                    |> List.map getStrengths
                    |> List.append [getSectionHeader "Strengths"]
                    |> List.append [class' "glass"]
                    |> Bulma.Column.column
                ]
            ]
        ]
    ] |> Sutil.Styling.withStyle styleSheet

