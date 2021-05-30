module Main.functions.miscellaneous

open Sutil
open Sutil.DOM
open Sutil.Attr
open Feliz

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
        Sutil.Attr.style [
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

