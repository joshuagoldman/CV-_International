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
        Css.height 200
        Css.width 190
    ]
    Sutil.Styling.rule ".glass" [
        Css.borderRadius 10
        Css.padding 2
        Css.margin 4
        Css.color color.black
        Css.fontWeightBold
        Css.boxShadow "0 0 1rem 0 rgba(0, 0, 0, 0.8)"
        Css.backgroundColor "rgba(220,243,255, 0.5)"
        
    ]
    Sutil.Styling.rule ".cv-name" [
        Css.padding 2
        Css.margin 10
        Css.color "rgba(220,243,255,0.8)"
        Css.fontSize 50
        Css.textDecorationUnderline
        Css.fontFamily "Brush Script MT, Brush Script Std, cursive"
    ]
    Sutil.Styling.rule ".core-competencies" [
        Css.padding 2
        Css.color "rgba(0,0,0,0.8)"
        Css.fontSize 30
        Css.textDecorationUnderline
    ]
    Sutil.Styling.rule ".cv-title" [
        Css.padding 2
        Css.marginBottom 15
        Css.color "rgba(220,243,255,0.9)"
        Css.fontSize 20
        Css.fontFamily "sanscrit"
    ]
    Sutil.Styling.rule ".background" [
        Css.backgroundPosition "no-repeat center center fixed"
        Css.height 470
        Css.backgroundRepeatNoRepeat
        Css.padding (length.px 15)
        Css.fontFamily "sans serif"
        Css.zIndex -1
        Css.backgroundImage "linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.9)), url(cv_background.jpg)"

    ]
    Sutil.Styling.rule ".background-content" [
        Css.backgroundPosition "no-repeat center center fixed"
        Css.height 1200
        Css.backgroundRepeatNoRepeat
        Css.padding (length.px 15)
        Css.fontFamily "sans serif"
        Css.zIndex -1
        Css.backgroundImage "linear-gradient( 109.5deg,  rgba(229,233,177,1) 11.2%, rgba(223,205,187,1) 100.2% );"
        Css.borderTop(length.px 2,borderStyle.solid,"black")

    ]
    Sutil.Styling.rule "a:hover" [
        Css.color "white"
    ]
    Sutil.Styling.rule "a" [
        Css.color "black"
    ]
    Sutil.Styling.rule ".border" [
        Css.borderStyleSolid
        Css.borderWidth 2
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

type PyramidFold = {
    NodeFactoryList: list<NodeFactory>
    CurrPos: int
}

let pyramidFoldInit = {
    NodeFactoryList = []
    CurrPos = 0
}

let getPyramidRow pyramidFold currPyrRow =
    let newRow =
        [pyramidFold.CurrPos + 1..pyramidFold.CurrPos + currPyrRow]
        |> List.map (fun pos -> 
                strengths
                |> List.item pos
                |> getStrengths pos
            )
        |> Bulma.Columns.isCentered
    
    { pyramidFold with NodeFactoryList = pyramidFold.NodeFactoryList @ [newRow]
                       CurrPos = pyramidFold.CurrPos + currPyrRow}

let view() = 
    // model is an IStore<ModeL>
    // This means we can write to it if we want, but when we're adopting
    // Elmish, we treat it like an IObservable<Model>
    let model, dispatch = () |> Store.makeElmish Main.state.init Main.state.update ignore

    Bulma.Column.column [
        Bulma.Columns.isCentered [
            class' "background"

            Bulma.Column.column [
                Bulma.Columns.isCentered [
                    class' "cv-name"
                    text "Maria Veber"
                ]

                Bulma.Columns.isCentered [
                    class' "cv-title"
                    text "Project Manager & Brand Manager"
                ]

                Bulma.Columns.isCentered [
                    basicInfos
                    |> List.take 3
                    |> List.map getBasicInfoReverse
                    |> Bulma.Column.isOneFifth

                    Bulma.Column.isHalf [
                        class' "cv-img"

                        Bulma.Columns.isCentered [
                            Bulma.Column.column [
                                Html.img [
                                    style [
                                        
                                        Css.boxShadow "0 0 1rem 0 rgba(220,243,255, 0.9)"
                                        Css.borderRadius (length.px 8)
                                    ]
                                    Attr.src "selfPortrait.jpg"
                                ]
                            ]
                        ]
                        Bulma.Columns.isCentered [
                            class' "glass"
                            Bulma.Column.column [
                                Html.span [
                                    class' "icon"                            
                                    Html.a [
                                        Attr.href "https://www.instagram.com/maryveber/"
                                        Html.i [
                                            class' "fab fa-instagram fa-lg"
                                            
                                        ]
                                    ]
                                ]
                            ]
                            Bulma.Column.column [
                                Html.span [
                                    class' "icon"
                                    Html.a [
                                        Attr.href "https://www.facebook.com/imariaweber/"
                                        Html.i [
                                            class' "fab fa-facebook-f fa-lg"
                                            
                                        ]
                                    ]
                                ]
                            ]
                            Bulma.Column.column [
                                Html.span [
                                    class' "icon"
                                    Html.a [
                                        Attr.href "https://www.linkedin.com/in/mariaveber/"
                                        Html.i [
                                            class' "fab fa-linkedin-in fa-lg"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]

                    basicInfos
                    |> List.skip 3
                    |> List.map getBasicInfo
                    |> Bulma.Column.isOneFifth
                ]
            ]
        ]
        Bulma.Columns.isCentered [
            class' "background-content"
            Bulma.Columns.columns [
                
                workInfos
                |> List.map getWorkInfo
                |> fun x -> (style [ Css.marginLeft 20 ; Css.marginRight 20 ; Css.borderRight(length.px 3, borderStyle.dotted, "black")]) :: x
                |> fun x ->
                    Bulma.Columns.columns [
                        Bulma.Column.column [
                            class' "core-competencies"
                            text "Experience"
                        ]
                    ]
                    |> fun y -> y :: x
                |> Bulma.Column.isOneThird

                [1..4]
                |> List.fold getPyramidRow pyramidFoldInit
                |> fun pyrFold -> pyrFold.NodeFactoryList
                |> fun pyrCntnt ->
                    Bulma.Columns.columns [
                        Bulma.Column.column [
                            style [
                                Css.textAlignCenter
                            ]
                            class' "core-competencies"
                            text "Core Competencies"
                        ]
                    ]
                    |> fun x -> x :: pyrCntnt
                |> fun contnt ->
                    languageSkilllevells
                    |> List.map getSkillLevel
                    |> List.append(
                            Bulma.Columns.columns [
                                Bulma.Column.column [
                                    class' "core-competencies"
                                    text "Language Skills"
                                ]
                            ]
                            |> fun z -> [z]
                        )
                    |> fun x -> contnt @ x
                |> fun x -> (style [ Css.marginLeft 20 ; Css.marginRight 20 ; Css.borderRight(length.px 3, borderStyle.dotted, "black")]) :: x
                |> Bulma.Column.isOneThird

                educationInfos
                |> List.map getEducationInfos
                |> fun x ->
                    Bulma.Columns.columns [
                        Bulma.Column.column [
                            style [
                                Css.textAlignRight
                                Css.marginRight 90
                            ]
                            class' "core-competencies"
                            text "Education"
                        ]
                    ]
                    |> fun y -> y :: x
                |> Bulma.Column.isOneThird
            ]
        ]
    ] |> Sutil.Styling.withStyle styleSheet

