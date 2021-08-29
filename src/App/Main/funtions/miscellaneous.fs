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
        Years = "Jun - Aug 2017"
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.fontWeightBold
                    Css.color color.black
                    Css.textDecorationUnderline
                ]
                Html.a [
                    Attr.href "https://www.bosch.se/en/our-company/bosch-in-sweden/mellansel/"
                    text "Material Planner, Bosch Rexroth AB Mellansel"
                ]
            ]
            Html.h6 [
                style [
                    Css.color color.black
                    Css.fontSize 14
                    Css.fontStyleItalic
                ]
                Html.p [
                    text "Bosch Rexroth is a leading supplier of large hydraulic drivesolutions. My work assignments included monitoring and analyzing the material supply need in order to ensure thecompany's stock balance."
                ]
            ]
        ]
    }
    {
        Years = "Okt 2018 -"
        Content = [
            class' "content"
            Html.h4 [
                style [
                    Css.color color.black
                    Css.textDecorationUnderline
                ]
                Html.p [
                    Html.a [
                        Attr.href "https://www.syntronic.com/"
                        text "Test System Developer, Syntronic AB"
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
                    text "Syntronic AB, founded in 1983, develop technical solutions in areas such as telecom, defence, industry, medtech and automotive. The company operates in 8 different countries with 1276 employees. Here, I am currently working towards the world's leading telecom company, developing test system software/hardware for their aftermarket services. This implies maintenance as well as development of test system software/hardware for both older and newer (5G) telecom products."
                ]
            ]
        ]
    }
]

let educationInfos = [
    {
        Years = "Aug 2013 - Aug 2018"
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
                    text "Master of Science in Energy Technology."
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
        Info = "+972559388237"
    }
    {
        Icon = "fas fa-envelope-open fa-lg"
        Info = "joshuagoldman94
        @gmail.com"
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

let proudOf = [
    {
        Icon = "fas fa-square-root-alt fa-2x"
        Info = "Got highest grade in multivariable calculus"
    }
    {
        Icon = "fas fa-music fa-2x"
        Info = "A splended piano player"
    }
]

let strengths = [
    {
        Icon = "fas fa-hands-helping fa-2x"
        Info = "Collaborative"
    }
    {
        Icon = "fas fa-dumbbell fa-2x"
        Info = "Hard working"
    }
    {
        Icon = "fas fa-cogs fa-2x"
        Info = "Love for automation"
    }
    {
        Icon = "fas fa-binoculars fa-2x"
        Info = "Can easly focus"
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
        Percent = 70.0
        SkillName = "Hebrew"
    }
    {
        Percent = 30.0
        SkillName = "German"
    }
]

let otherSkills = [
    {
        Percent = 80.0
        SkillName = "C#"
    }
    {
        Percent = 85.0
        SkillName = "F#"
    }
    {
        Percent = 40.0
        SkillName = "Javascript"
    }
    {
        Percent = 55.0
        SkillName = "MATLAB"
    }
    {
        Percent = 40.0
        SkillName = "Python"
    }
    {
        Percent = 50.0
        SkillName = "Jenkins"
    }
    {
        Percent = 70.0
        SkillName = "Git"
    }
    {
        Percent = 50.0
        SkillName = "Node.js"
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
            class' "column is-one-quarter"
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
            class' "columns is-centered"
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
                class' "column is-one-quarter"
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
            text "Joshua Goldman"
            style [
                Css.color "black"
            ]
        ]
        Html.p [
            class' "subtitle"
            text "Test System Developer"
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

