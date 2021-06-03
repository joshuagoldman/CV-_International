module Main.functions.miscellaneous

open Sutil
open Sutil.DOM
open Sutil.Attr
open Feliz
open Main.types

type InfoWithYear = {
    Years: string
    Title: string
    Info: string
}

type ContentWithContent = {
    Years: string
    Title: string
    SubTitle: string
    Tasks: list<string>
}

let workInfos = [
    {
        Years = "2015 – 2021"
        Title = "Senior Brand Manager"
        SubTitle = "SPPO GROUP Moscow distribution companye"
        Tasks = [
            "Distribution and launch new brand on the market"
            "Management of the wholesale and retail department"
            "Increase brand awareness more than 200% every year"
            "B2C: online store, offline monobrand eyewear store"
            "Create and implement social media accounts (@retrosuperfuture_russia, @seen.moscow)"
            "Manage PR-campaigns with Celebrity influencers, journalists, bloggers"
        ]
    }
    {
        Years = "2013 – 2015"
        Title = "Sales Manager, Buyer"
        SubTitle = "Marie Claire, Hearst Shkulev Media, Moscow, Publishing House"
        Tasks = [
            "Arrange more than 30 new wholesale customers"
            "Presentations to customers at Opti exhibitions MIDO Milan, SILMO Paris, OPTI Munich"
            "Increase wholesales revenue"
            "Provided customer support on a daily basis"
            
        ]
    }
    {
        Years = "2012 – 2013"
        Title = "Senior Brand Manager Assistant"
        SubTitle = "Marie Claire, Hearst Shkulev Media, Moscow, Publishing House"
        Tasks = [
            "Manage daily calendars, arrange all meetings and appointments"
            "Update marieclaire.ru core presentations, including capabilities and sponsorship decks with accurate information"
            "Coordinated with marieclaire.com editorial team to execute all social media posts across MARIECLAIRE's various channels (Facebook, Instagram, Twitter, etc.)"
            "participation in the preparation and holding of events, exhibitions"
            "Implementation personal orders of the publisher"
            
        ]
    }
]

let educationInfos = [
    {
        Years = "Feb 2010 – Jul 2014"
        Title = "State University of Management (SUM) Moscow (Russia)"
        Info = "Bachelor's Degree, Marketing "
    }
    {
        Years = "Jul 2020"
        Title = "University of Pennsylvania"
        Info = "English for Business and Entrepreneurship. Credential ID PTJXLK3ZVYE8 "
    }
]

type IconInfo = {
    Icon : string
    Info : string
}

let basicInfos = [
    {
        Icon = "fas fa-home fa-lg"
        Info = "Tel Aviv, Israel"
    }
    {
        Icon = "far fa-calendar-alt fa-lg"
        Info = "1994-12-31"
    }
    {
        Icon = "fas fa-phone fa-lg"
        Info = "052 244 57 22"
    }
    {
        Icon = "fas fa-envelope-open fa-lg"
        Info = "i.mariaweber@gmail.com"
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
        Info = "Project Management "
    }
    {
        Icon = "fas fa-cogs fa-2x"
        Info = "Strategic Planning"
    }
    {
        Icon = "fas fa-users-cog fa-2x"
        Info = "Social Media Management"
    }
    {
        Icon = "fas fa-people-carry fa-2x"
        Info = "Brand Development"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "Business Development"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "Sales Presentation"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "Strategic Planning"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "PR"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "Product Launch & Product Education"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "Excellent communication skills"
    }
    {
        Icon = "fas fa-laptop fa-2x"
        Info = "High organizational skills"
    }
]

type SkillLevelInfo = {
    Percent: float
    SkillName: string
}

let languageSkilllevells = [
    {
        Percent = 100.0
        SkillName = "Russian"
    }
    {
        Percent = 90.0
        SkillName = "English"
    }
    {
        Percent = 40.0
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
                class' "progress is-medium is-danger"
                Attr.value info.Percent
                Attr.max 100.0
            ]
        ]
        Html.div [
            class' "column"
            text percentageWritten
        ]
    ]

let getTasks task =
    Bulma.Columns.isCentered [
        style [
            Css.fontWeightBold
            Css.marginBottom 0
        ]
        Bulma.Column.isOneFifth [
            text "-"
            style [
                Css.fontWeightBold
                Css.fontSize 20
                Css.textAlignRight
            ]
        ]
        Bulma.Column.column [
            text task
            style [
                Css.fontWeightBold
                Css.fontSize 13
                Css.fontStyleItalic
                Css.marginTop 6
            ]
        ]
    ]

let getWorkInfo ( info: ContentWithContent ) =
        [
            Bulma.Columns.columns [
                Bulma.Column.isOneThird [
                    text info.Years
                    style [
                        Css.fontWeightBold
                        Css.color Feliz.color.black
                        Css.fontSize 19
                        Css.textAlignLeft
                    ]

                ]
            ]

            Bulma.Columns.isCentered [
                text info.Title
                style [
                    Css.fontWeightBold
                    Css.color Feliz.color.black
                    Css.fontSize 19
                    Css.textDecorationUnderline
                    Css.textAlignCenter
                ]
            ]
                
            Bulma.Columns.isCentered [
                text info.SubTitle
                style [
                    Css.fontWeightBold
                    Css.color Feliz.color.black
                    Css.fontSize 13
                    Css.textAlignCenter
                ]
            ]
        ]
        |> fun x ->
            info.Tasks
            |> List.map getTasks
            |> fun y ->
                x @ y
        |> Bulma.Column.column
        |> fun x -> [x]
        |> Bulma.Columns.isCentered

let getEducationInfos ( info: InfoWithYear ) =
    [
        Bulma.Columns.columns [
            Bulma.Column.isFourFifths [
                text info.Years
                style [
                    Css.fontWeightBold
                    Css.color Feliz.color.black
                    Css.fontSize 19
                    Css.textAlignRight
                ]

            ]
        ]

        Bulma.Columns.columns [
            Bulma.Column.column [
                text info.Title
                style [
                    Css.fontWeightBold
                    Css.color Feliz.color.black
                    Css.fontSize 17
                    Css.textDecorationUnderline
                    Css.maxWidth 330
                    Css.textAlignCenter
                ]
            ]
        ]
    ]
    |> fun x ->
        Bulma.Columns.columns [
            text (info.Info)
            style [
                Css.fontWeightBold
                Css.fontSize 13
                Css.fontStyleItalic
                Css.maxWidth 300
            ]
        ]
        |> fun y ->
            x @ [y]
    |> Bulma.Column.column
    |> fun x -> [x]
    |> Bulma.Columns.isCentered

let getBasicInfo info =
    Html.div [
        style [
            Css.fontSize 14
            Css.textAlignLeft
        ]
        class' "columns glass border"
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
            text info.Info
        ]
    ]

let getBasicInfoReverse info =
    Html.div [
        style [
            Css.fontSize 14
            Css.textAlignRight
        ]
        class' "columns glass border"
        Html.div [
            class' "column is-four-fifths"
            text info.Info
        ]
        Html.div [
            class' "column"
            Html.span [
                class' "icon"
                Html.i [
                    class' info.Icon
                ]
            ]
        ]
    ]

let colors = [
    ""
    
]

let colorsList = [
    "linear-gradient(45deg, #ff9a9e 0%, #fad0c4 99%, #fad0c4 100%);"
    "linear-gradient(45deg, #ff9a9e 0%, #fad0c4 99%, #fad0c4 100%);"
    "linear-gradient(to right, #ff8177 0%, #ff867a 0%, #ff8c7f 21%, #f99185 52%, #cf556c 78%, #b12a5b 100%);"
    "linear-gradient(120deg, #d4fc79 0%, #96e6a1 100%);"
    "linear-gradient(120deg, #84fab0 0%, #8fd3f4 100%);"
    "linear-gradient(to right, #bdc3c7, #2c3e50);"
    "linear-gradient(to right, #b92b27, #1565c0);"
    "linear-gradient(to right, #f12711, #f5af19);"
    "linear-gradient(to right, #1e9600, #fff200, #ff0000);"
    "linear-gradient(to right, #636363, #a2ab58);"
    "linear-gradient(to right, #333333, #dd1818);"
    "Crimson"
    "Crimson"
]

let getStrengths colNum info =
    let getCurrColor = 
        colorsList
        |> List.item colNum
    Bulma.Column.column [
        Html.div [
            Sutil.Attr.style [
                Css.color "black"
                Css.fontWeightBold
                Css.fontSize 14
                Css.borderRadius (length.px 8)
                Css.borderStyleSolid
                Css.borderWidth 2
                Css.padding 2
                Css.marginRight 2
                Css.marginBottom (length.px 0.1)
                Css.textAlignCenter
                Css.backgroundImage getCurrColor
            ]
            class' "columns is-centered"
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

