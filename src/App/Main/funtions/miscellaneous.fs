module Main.functions.miscellaneous

open Sutil
open Sutil.DOM
open Sutil.Attr
open Feliz
open Main.types

type InfoWithYear = {
    Years: string
    Title: string
}

type ContentWithContent<'Node> = {
    Years: string
    Content: seq<'Node>
}

let workInfos = [
    {
        Years = "Okt 2019 - Mars 2019"
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                    Css.textDecorationUnderline
                ]
                Html.a [
                    Attr.href "https://www.dammvippanumea.se/hemtjanst/"
                    text "Manager, DV Hemtjänst i Umeå AB"
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                    Css.fontSize 14
                    Css.fontStyleItalic
                ]
                Html.p [
                    text "DV Hemtjänst i Umeå AB (DammVippan Home Services in
                    Umeå Ltd) is a company that is specialized in nursing, private
                    home service, and home care.
                    "
                ]
            ]
        ]
    }
    {
        Years = "Mar 2019 - Okt 2020"
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.color color.black
                    Css.textDecorationUnderline
                ]
                Html.p [
                    Html.a [
                        Attr.href "https://malmo.se/"
                        text "Social Worker in the Financial Assistance Department, Malmö stad"
                    ]
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                    Css.fontSize 14
                    Css.fontStyleItalic
                ]
                Html.p [
                    text "Administrating state financed economical support."
                ]
            ]
        ]
    }
    {
        Years = "Jan 2021 -"
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.color color.black
                    Css.textDecorationUnderline
                ]
                Html.a [
                    Attr.href "https://www.thenorman.com/"
                    text "Receptionist, The Norman Tel Aviv."
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                    Css.fontSize 14
                    Css.fontStyleItalic
                ]
                Html.p [
                    text "Nestled on a picturesque city square, The Norman, the only
                    luxury boutique hotel in Tel Aviv, lies in the heart of the White
                    City; Tel Aviv’s world-famous UNESCO heritage site of historic
                    Bauhaus architecture buildings."
                ]
            ]
        ]
    }
]

let educationInfos = [
    {
        Years = "Aug 2014 - Aug 2018"
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                    Css.textDecorationUnderline
                ]
                Html.a [
                    Attr.href "https://www.umu.se/en/"
                    text "Umeå University"
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                    Css.fontSize 14
                    Css.fontStyleItalic
                ]
                Html.p [
                    text "Bachelor and Master of Science in social science education."
                ]
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
        Info = "Haroe 268, Ramat Gan"
    }
    {
        Icon = "far fa-calendar-alt fa-lg"
        Info = "1994-12-31"
    }
    {
        Icon = "fas fa-phone fa-lg"
        Info = "+972523589560"
    }
    {
        Icon = "fas fa-envelope-open fa-lg"
        Info = "estermiragoldman
        @hotmail.com"
    }
    {
        Icon = "fas fa-id-card-alt fa-lg"
        Info = "ID:3-1924217-8"
    }
    {
        Icon = "fas fa-car fa-lg"
        Info = "Drivers license"
    }
]

let strengths = [
    {
        Icon = "fas fa-hands-helping fa-2x"
        Info = "Collaborative"
    }
    {
        Icon = "fas fa-cogs fa-2x"
        Info = "Hard Working"
    }
    {
        Icon = "fas fa-users-cog fa-2x"
        Info = "Good at communicating"
    }
    {
        Icon = "fas fa-people-carry fa-2x"
        Info = "Service-minded"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "Technical"
    }
]

type SkillLevelInfo = {
    Percent: float
    SkillName: string
}

let languageSkilllevells = [
    {
        Percent = 100.0
        SkillName = "Swedish"
    }
    {
        Percent = 95.0
        SkillName = "English"
    }
    {
        Percent = 75.0
        SkillName = "Hebrew"
    }
]

let otherSkills = [
    {
        Percent = 60.0
        SkillName = "Excel"
    }
    {
        Percent = 30.0
        SkillName = "Programming Excel (C#)"
    }
    {
        Percent = 30.0
        SkillName = "Piano Playing"
    }
]

let getSkillLevel ( info: SkillLevelInfo ) =
    let percentageWritten =
        (info.Percent |> string) + "%"

    Html.div [
        class' "columns"
        style [
            Css.color Feliz.color.black
        ]
        Html.div [
            class' "column"
            text info.SkillName
        ]
        Html.div [
            class' "column is-two-thirds"
            style [
                Css.color "black"
                Css.maxWidth 260
            ]
            Html.progress [
                class' "progress is-medium is-link"
                Attr.value info.Percent
                Attr.max 100.0
            ]
        ]
        Html.div [
            class' "column"
            text percentageWritten
        ]
    ]

let getWorkInfo ( info: InfoWithYear ) =
    Html.li [
        Html.p [
            class' "content"
            Html.h4 [
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
    Bulma.Columns.columns [
        Bulma.Column.column [
            Bulma.Columns.columns [
                Bulma.Column.column [
                    
                    Html.p [
                        Html.h3 [
                            text info.Years
                            style [
                                Css.fontWeightBold
                                Css.color Feliz.color.black
                                Css.fontSize 23
                            ]
                        ]
                    ]
                ]
            ]
            Bulma.Columns.isCentered [
                Bulma.Column.isOneFifth[]
                Bulma.Column.column (info.Content |> Seq.toList)
            ]
        ]
    ]

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
            Html.p [
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
            class' "columns"
            Html.div [
                class' "column"
                style [
                    Css.marginTop 10
                    Css.marginLeft 40
                ]
                Html.div [
                    class' "columns"
                    Html.span [
                        text info.Info
                    ]
                ]
            ]
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
        ]
    ]
   
let initialBasicInfo =
    [
        class' "content"
        style [
            Css.padding 10
        ]
        Html.img[
            class' "cv-img"
            Attr.src "selfPortrait.jpg"
        ]
        Html.p [
            class' "title"
            text "Mira Goldman"
            style [
                Css.color "black"
            ]
        ]
        Html.p [
            class' "subtitle"
            text "Receptionist"
            style [
                Css.color "black"
            ]
        ]
    ]

let basicInfo =
    basicInfos
    |> List.map (fun info ->
            info |> getBasicInfo)

let getSectionHeader name =
    Bulma.Columns.isCentered [
        Html.h2 [
            style [
                Css.fontSize 28
                Css.fontWeightBold
                Css.textDecorationUnderline
            ]
            text name
        ]
    ]

