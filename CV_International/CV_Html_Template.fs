module CV_Html_Template

open CV_International.Html
open CV_International.Models

let strengths model =
    match model.Extra_Info with
    | Binary_Choice.Yes_Choice extras ->
        seq[Html.none]
    | _ ->
        seq[Html.none]

let educations educations =
    let dateStr education = 
        let endDate = 
            match education.Education_Period.End_Date with
            | Work_Type.With_Ongoing -> ""
            | Work_Type.No_Ongoing date -> date

        let date_total = 
            education.Education_Period.Start_Date + " - " + endDate

        date_total
    educations
    |> Seq.map (fun education ->
            Html.li [
                prop.children [
                    Html.div [
                        prop.text (dateStr education)
                        prop.className "date"
                    ]
                    Html.div [
                        prop.className "info"
                        prop.children [
                            Html.p [
                                prop.children[
                                    Html.a[
                                        prop.href education.University.Link
                                        prop.text education.University.Link_Title
                                    ]
                                ]
                                prop.className "semi-bold"
                            ]
                            Html.p [
                                prop.text education.Education_TItle
                            ]
                        ]
                    ]
                ]
            ]
        )

let basic_info_html_template model =
    seq[
        Html.div [
            prop.className "title"
            prop.children [
                Html.p [
                    prop.text model.Basic.Name
                    prop.className "bold"
                ]
                Html.p [
                    prop.text "Receptionist"
                    prop.className "regular"
                ]
            ]
        ]
        Html.ul [
            prop.children [
                Html.li [
                    prop.children [
                        Html.div [
                            prop.className "icon"
                            prop.children [
                                Html.i [
                                    prop.className "fas fa-user-circle"
                                ]
                            ]
                        ]
                        Html.div [
                            prop.className "data"
                            prop.text ("ID: " + model.Basic.ID.Swedish)
                        ]
                    ]
                ]
                Html.li [
                    prop.children [
                        Html.div [
                            prop.className "icon"
                            prop.children [
                                Html.i [
                                    prop.className "fas fa-mobile-alt"
                                ]
                            ]
                        ]
                        Html.div [
                            prop.text model.Basic.Telephone_Number
                            prop.className "data"
                        ]
                    ]
                ]
                Html.li [
                    prop.children [
                        Html.div [
                            prop.className "emailicon"
                            prop.children [
                                Html.i [
                                    prop.className "fas fa-envelope-open"
                                ]
                            ]
                        ]
                        Html.div [
                            prop.text model.Basic.Email
                            prop.className "data"
                        ]
                    ]
                ]
                Html.li [
                    prop.children [
                        Html.div [
                            prop.className "icon"
                            prop.children [
                                Html.i [
                                    prop.className "fas fa-home"
                                ]
                            ]
                        ]
                        Html.div [
                            prop.children[
                                Html.a[
                                    prop.text model.Basic.Address.Link_Title
                                    prop.href model.Basic.Address.Link
                                ]
                            ]
                            prop.className "data"
                        ]
                    ]
                ]
            ]
        ]
    ]
    

let skills_html_template languages =
        languages
        |> Seq.map (fun lang ->
                Html.li [
                    prop.children [
                        Html.div [
                            prop.text lang.Language_name
                            prop.className "skill_name"
                        ]
                        Html.div [
                            prop.className "skill_progress"
                            prop.children [
                                Html.span [
                                    prop.style_html ("width: " + (lang.Rating |> string) + "%;")
                                ]
                            ]
                        ]
                        Html.div [
                            prop.text ((lang.Rating |> string) + "%")
                            prop.className "skill_per"
                        ]
                    ]
                ]
            )

let experience_html_template experience =
    let dateStr = 
        let endDate = 
            match experience.Period.End_Date with
            | Work_Type.With_Ongoing -> ""
            | Work_Type.No_Ongoing date -> date

        let date_total = 
            experience.Period.Start_Date + " - " + endDate

        date_total

    Html.li [
        prop.children [
            Html.div [
                prop.text dateStr
                prop.className "date"
            ]
            Html.div [
                prop.className "info"
                prop.children [
                    Html.p [ 
                        (experience.Job_Title + ", ")
                        |> prop.text
                        prop.children[
                            Html.a[
                                prop.text experience.Company_Name.Link_Title
                                prop.href experience.Company_Name.Link
                            ]
                        ]
                        prop.className "semi-bold"
                    ]
                    Html.p [
                        experience.Description
                        |> String.concat "\n"
                        |> prop.text
                    ]
                ]
            ]
        ]
    ]

let produOf model =
    match model.Extra_Info with
    | Binary_Choice.Yes_Choice extras ->
        extras.Proud_Of
        |> Seq.map (fun proudness ->
                Html.li [
                    prop.children [
                        Html.div [
                            prop.className "icon"
                            prop.children [
                                Html.i [
                                    prop.className proudness.Proudness_Url
                                ]
                            ]
                        ]
                        Html.div [
                            prop.className "data"
                            prop.children [
                                Html.p [
                                    prop.text proudness.Proudness_Description
                                    prop.className "semi-bold"
                                ]
                            ]
                        ]
                    ]
                ]
            )
    | _ -> seq[Html.none]

let template (main_model : CV_International.Models.Main_Model ) =
    Html.html [
        prop.lang "en"
        prop.children [
            Html.head [
                prop.children [
                    Html.meta [
                        prop.charset "UTF-8"
                    ]
                    Html.title [
                        prop.text "Resume/CV Design"
                    ]
                    Html.link [
                        prop.rel "stylesheet"
                        prop.href "styles.css"
                    ]
                    Html.script [
                        prop.src "https://kit.fontawesome.com/b99e675b6e.js"
                    ]
                ]
            ]
            Html.body [
                prop.children [
                    Html.div [
                        prop.className "resume"
                        prop.children [
                            Html.div [
                                prop.className "resume_left"
                                prop.children [
                                    Html.div [
                                        prop.className "resume_profile"
                                        prop.children [
                                            Html.img [
                                                prop.src "Photo_Mira_1.jpg"
                                                prop.alt "profile_pic"
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.className "resume_content"
                                        prop.children [
                                            Html.div [
                                                prop.className "resume_item resume_info"
                                                main_model
                                                |> basic_info_html_template
                                                |> prop.children
                                            ]
                                            Html.div [
                                                prop.className "resume_item resume_skills"
                                                prop.children [
                                                    Html.div [
                                                        prop.className "title"
                                                        prop.children [
                                                            Html.p [
                                                                prop.text "Languages"
                                                                prop.className "bold"
                                                            ]
                                                        ]
                                                    ]
                                                    Html.ul [
                                                        match main_model.Extra_Info with
                                                        | Binary_Choice.Yes_Choice extras ->
                                                            extras.Languages
                                                            |> skills_html_template
                                                            |> prop.children
                                                        | Binary_Choice.No_Choice ->
                                                            seq[(Html.none)]
                                                            |> prop.children
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.className "resume_item resume_proud_of"
                                                prop.children [
                                                    Html.div [
                                                        prop.className "title"
                                                        prop.children [
                                                            Html.p [
                                                                prop.text "Strengths"
                                                                prop.className "bold"
                                                            ]
                                                        ]
                                                    ]
                                                    Html.ul [
                                                        main_model
                                                        |> produOf
                                                        |> prop.children
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.className "resume_right"
                                prop.children [
                                    Html.div [
                                        prop.className "resume_item resume_work"
                                        prop.children [
                                            Html.div [
                                                prop.className "title"
                                                prop.children [
                                                    Html.p [
                                                        prop.text "Work Experience"
                                                        prop.className "bold"
                                                    ]
                                                ]
                                            ]
                                            Html.ul [
                                                main_model.Experiences
                                                |> Seq.map (fun experience ->
                                                        experience |> experience_html_template
                                                    )
                                                |> prop.children
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.className "resume_item resume_education"
                                        prop.children [
                                            Html.div [
                                                prop.className "title"
                                                prop.children [
                                                    Html.p [
                                                        prop.text "Education"
                                                        prop.className "bold"
                                                    ]
                                                ]
                                            ]
                                            Html.ul [
                                                main_model.Educations
                                                |> educations
                                                |> prop.children
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
