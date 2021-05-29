module App

open Sutil
open Sutil.DOM
open Sutil.Styling
open Feliz
open Sutil.DOM.CssRules
open Sutil.Bulma.Helpers
open Feliz.Engine
open Sutil
open Sutil.Attr

type Model = { Counter : int }

// Model helpers
let getCounter m = m.Counter

type Message =
    | Increment
    | Decrement

let init () : Model = { Counter = 0 }

let update (msg : Message) (model : Model) : Model =
    match msg with
    |Increment -> { model with Counter = model.Counter + 1 }
    |Decrement -> { model with Counter = model.Counter - 1 }

let styleSheet = [
    rule ".main-background" [
        Css.positionAbsolute
        Css.backgroundImage "linear-gradient(rgba(0, 0, 0, 0.3),rgba(0, 0, 0, 0.3)), url('cv_background.jpg')"
        Css.zIndex -1
        Css.backgroundSizeCover
        Css.backgroundRepeatRepeatY
        Css.height (length.px 1100)
        Css.width (length.px 1400)
    ]
    rule ".margin-standard" [
        Css.fontWeightBold
        Css.padding 30
        Css.color "black"
    ]
    rule ".cv-img" [
        Css.height 230
        Css.width 480
        Css.borderRadius (Feliz.length.percent 50)
    ]
    rule ".glass" [
        Css.boxShadow "0 0 1rem 00 rgba(109, 155, 195, 0.8)"
        Css.backgroundColor "rgba(255, 255, 255, .55);"
        Css.margin 20
        Css.padding 30
        Css.borderRadius 10
    ]
]

type InfoWithYear = {
    Years: string
    Title: string
}

let workInfos = [
    {
        Years = "2021-"
        Title = "מאבטח במשרד ראש הממשלה"
    }
    {
        Years = "2020-2021"
        Title = "מאבטח ברשות המיסים- מתקדם ב"
    }
    {
        Years = "2019-2020 "
        Title = "מאבטח בקריית הממשלה ת\"א-מתקדם ב\'"
    }
    {
        Years = "2017-2018 "
        Title = "2018 מאבטח בחברת applied materials"
    }
]

type ContentWithContent<'Node> = {
    Years: string
    Content: seq<'Node>
}

let tsavaInfos = [
    {
        Years = "2013-2016 "
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                ]
                Html.p [
                    text "חייל רגלים -"
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                ]
                Html.ul [
                    Html.li [
                        text "לוחם בחטיבת כפיר, גדוד 93-חרוב , שחרור בדרגת סמל ראשון"
                    ]
                    Html.li [
                        text "לוחם בתפקיד נוסף: תופר ציוד טקטי"
                    ]
                    Html.li [
                        text "ייצור, פיתוח ועיצוב ציוד לחימה"
                    ]
                    Html.li [
                        text "פיקוח כולל על כל התנהלות המתפרה-  מכירות, כספים, הזמנות, מלאי ושירות."
                    ]
                ]
            ]
        ]
    }
]

let educationInfos = [
    {
        Years = "2018-2019"
        Content = [
            class' "content"
            Html.h5 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                ]
                Html.p [
                    text "תואר ראשון בעיצוב תעשייתי, המכון הטכנולוגי חולון.
                    הסמכה על מגוון רחב של כלי עבודה, מכונות ותוכנות במספר תחומים, כגון:"
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                ]
                Html.ul [
                    Html.li [
                        text "מתכת, עץ, פלסטיקה וצבע."
                    ]
                    Html.li [
                        text "בנוסף שליטה מלאה ב, Illustrator"
                    ]
                    Html.li [
                        text "משתמש בכל תוכנות, Office"
                    ]
                    Html.li [
                        text "(פרישה לאחר שנה א'), Photoshop"
                    ]
                ]
            ]
        ]
    }
    {
        Years = "2017"
        Content = [
            class' "content"
            Html.h6 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                ]
                text "מכינה לעיצוב, המכינה הבינתחומית לעיצוב ואדריכלות"
            ]
        ]
    }
    {
       Years = "2017"
       Content = [
           class' "content"
           Html.h6 [
               style [
                   Css.fontWeightBold
                   Css.color color.black
               ]
               text "קורס אנגלית, Wall street ראשון לציון"
           ]
       ]
    }
    {
        Years = "2013-2001 "
        Content = [
            class' "content"
            Html.h6 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                ]
                text "השכלה תיכונית - בגרות מלאה, תיכון יצחק רבין מזכרת בתיה."
            ]
        ]
     }
]

type IconInfo = {
    Icon : string
    Info : string
}

let basicInfos = [
    {
        Icon = "fas fa-home fa-lg"
        Info = "מזכרת בתיה"
    }
    {
        Icon = "far fa-calendar-alt fa-lg"
        Info = "29.9.95"
    }
    {
        Icon = "fas fa-phone fa-lg"
        Info = "0549792527"
    }
    {
        Icon = "fas fa-envelope-open fa-lg"
        Info = "matand299@gmail.com"
    }
    {
        Icon = "fas fa-id-card-alt fa-lg"
        Info = "מספר זהות: 206084683"
    }
    {
        Icon = "fas fa-user-friends fa-lg"
        Info = "מצב משפחתי: רווק"
    }
    {
        Icon = "fas fa-car fa-lg"
        Info = "נייד עם רכב"
    }
]

let strengths = [
    {
        Icon = "fas fa-people-arrows fa-2x"
        Info = "הנני בעל יחסי אנוש מצוינים"
    }
    {
        Icon = "fas fa-hands-helping fa-2x"
        Info = "שירותי"
    }
    {
        Icon = "fas fa-cogs fa-2x"
        Info = "טכני"
    }
    {
        Icon = "fas fa-sort-amount-up-alt fa-2x"
        Info = "דקדקן ופרקטי"
    }
    {
        Icon = "fas fa-users-cog fa-2x"
        Info = "יכולת ביטוי ברמה גבוהה ויכולת עבודה בצוות"
    }
]

type SkillLevelInfo = {
    Percent: float
    SkillName: string
}

let languageSkilllevells = [
    {
        Percent = 100.0
        SkillName = "עברית"
    }
    {
        Percent = 95.0
        SkillName = "אנגלית"
    }
]

let getSkillLevel ( info: SkillLevelInfo ) =
    let percentageWritten =
        (info.Percent |> string) + "%"

    Html.div [
        class' "columns is-centered"
        style [
            Css.color Feliz.color.black
        ]
        Html.div [
            class' "column"
            text percentageWritten
        ]
        Html.div [
            class' "column is-two-thirds"
            style [
                Css.color "black"
            ]
            Html.progress [
                class' "progress is-medium is-link"
                Attr.value info.Percent
                Attr.max 100.0
            ]
        ]
        Html.div [
            class' "column"
            text info.SkillName
        ]
    ]

let getWorkInfo ( info: InfoWithYear ) =
    Html.li [
        Html.p [
            class' "content"
            Html.h3 [
                text info.Years
                style [
                    Css.fontWeightBold
                    Css.color Feliz.color.black
                ]
            ]
            Html.h6 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                ]
                text info.Title
            ]
        ]
    ]

let getEducationInfos ( info: ContentWithContent<NodeFactory> ) =
    [
        Html.p [
            Html.h3 [
                text info.Years
                style [
                    Css.fontWeightBold
                    Css.color Feliz.color.black
                ]
            ]
        ]
    ] 
    |> fun x -> x @ (info.Content |> Seq.toList)
    |> Html.li 

let getBasicInfo info =
    Html.div [
        class' "columns is-centered"
        Html.div [
            class' "column is-one-fifth"
            Html.span [
                class' "icon"
                Html.i [
                    class' info.Icon
                ]
            ]
        ]
        Html.div [
            class' "column is-four-fifths"
            Html.span [
                text info.Info
            ]
        ]
    ]

let getStrengths info =
    Html.div [
        class' "content"
        style [
            Css.color "black"
            Css.fontWeightBold
        ]
        Html.div [
            class' "columns is-centered"
            Html.div [
                class' "column is-one-fifth"
                Html.span [
                    class' "icon-text"
                    Html.span [
                        class' "icon"
                        Html.i [
                            class' info.Icon
                        ]
                    ]
                ]
            ]
            Html.div [
                class' "column"
                style [
                    Css.marginTop 10
                ]
                Html.div [
                    class' "columns is-centered"
                    Html.span [
                        text info.Info
                    ]
                ]
            ]
        ]
    ]
   
let initialBasicInfo =
    [
        class' "content"
        style [
            Css.padding 20
        ]
        Html.img[
            class' "cv-img"
            Attr.src "selfPortrait.jpg"
        ]
        Html.p [
            class' "title"
            text "מתן דואק"
            style [
                Css.color "black"
            ]
        ]
        Html.p [
            class' "subtitle"
            text "מאבטח"
            style [
                Css.color "black"
            ]
        ]
    ]

let basicInfo =
    basicInfos
    |> List.map (fun info ->
            info |> getBasicInfo)

let langiageSKills =
    languageSkilllevells
    |> List.map getSkillLevel
    |> fun x ->
        Html.div [
            class' "content"
            Html.h2 [
                style [
                    Css.fontWeightBold
                    Css.color "black"
                ]
                text "שפות"
            ]

        ] 
        |> fun y -> y :: x

// In Sutil, the view() function is called *once*
let view() =

    // model is an IStore<ModeL>
    // This means we can write to it if we want, but when we're adopting
    // Elmish, we treat it like an IObservable<Model>
    let model, dispatch = () |> Store.makeElmishSimple init update ignore
    
    Html.div[
        Html.div [
            class' "main-background"
        ]
        Html.div [
            class' "columns is-centered margin-standard"
            style [
                Css.padding 11
            ]
            Html.div [
                class' "column is-one-quarter"
                Html.div [
                    class' "tile is-child notification glass"

                    initialBasicInfo @ basicInfo @ langiageSKills
                    |> Html.div 
                ]
            ]
            Html.div [
                style [
                    Css.fontSize 15
                    Css.fontWeightBold
                    Css.color "black"
                ]
                class' "column"
                Html.div [
                    class' "columns is-centered"
                    Html.div [
                        class' "column"
                        
                        Html.div [
                            class' "columns is-centered"
                            Html.div [
                                class' "column glass"
                                Html.p [
                                    class' "title"
                                    text "ניסיון תעסוקתי"
                                    style [
                                        Css.color "black"
                                    ]
                                ]
                                Html.p [
                                    class' "content"

                                    workInfos
                                    |> Seq.map getWorkInfo
                                    |> Html.ul
                                ]
                            ]
                        ]
                        Html.div [
                            class' "columns is-centered"
                            Html.div [
                                class' "column glass"
                                Html.article [
                                    Html.p [
                                        class' "title"
                                        text "שירות צבאי"
                                        style [
                                            Css.color "black"
                                        ]
                                    ]
                                    Html.p [
                                        class' "content"

                                        tsavaInfos
                                        |> Seq.map getEducationInfos
                                        |> Html.ul
                                    ]

                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        class' "column"
                        Html.div [
                            class' "columns is-centered"
                            Html.div [
                                class' "column glass"
                                Html.article [
                                    Html.p [
                                        class' "title"
                                        text "השכלה"
                                        style [
                                            Css.color "black"
                                        ]
                                    ]
                                    Html.p [
                                        class' "content"

                                        educationInfos
                                        |> Seq.map getEducationInfos
                                        |> Html.ul
                                    ]

                                ]
                            ]
                        ]
                        Html.div [
                            class' "columns is-centered"
                            Html.div [
                                class' "column"
                                Html.article [
                                    class' "tile is-child notification glass"
                                    Html.div [
                                        class' "columns is-centered"
                                        Html.h1 [
                                            text "תמצית"
                                            style [
                                                Css.color "black"
                                                Css.fontSize 30
                                                Css.fontWeightBold
                                            ]
                                        ]
                                    ]
                                    Html.p [
                                        class' "content"

                                        strengths
                                        |> Seq.map getStrengths
                                        |> Html.ul
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]

    ] |> withStyle styleSheet

// Start the app
view() |> mountElement "sutil-app"