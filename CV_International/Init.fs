module CV_International.Init

open System
open CV_International
open CV_International.Models
open CV_International.Html

open System.IO
open System.Text.RegularExpressions


let basic_information = 
    {
        Picture_Url = ""
        Name = "Mira Goldman"
        Email = "Estermiragoldman@hotmail.com"
        Location = 
            {
                Link_Title = "Haroe 268, Ramat Gan, Israel"
                Link = "https://www.google.se/search?q=haroe+268+israel&source=hp&ei=DhOgYK-WC9ybjLsPmrKDgAw&iflsig=AINFCbYAAAAAYKAhHn2ANm0oA-UjZt3e_pvv1VdldF4P&oq=haroe+268+israel&gs_lcp=Cgdnd3Mtd2l6EAMyAggmOgIIADoICAAQxwEQowI6AgguOgUILhCTAjoICAAQxwEQrwE6BAgAEAo6BAguEAo6BAgAEB46CggAEMcBEK8BEBM6CAgAEBYQHhATOgUIIRCgAToECCEQFToHCCEQChCgAVDoP1iNe2CQgQFoAXAAeACAAbQBiAHIF5IBBDAuMjCYAQCgAQGqAQdnd3Mtd2l6&sclient=gws-wiz&ved=0ahUKEwiv1YzWqMzwAhXcDWMBHRrZAMAQ4dUDCAc&uact=5#"
            }
        Telephone_Number = "+972523589560"
        Address =
            {
                Link_Title = "Haroe 268, Ramat Gan, Israel"
                Link = "https://www.google.se/search?q=haroe+268+israel&source=hp&ei=DhOgYK-WC9ybjLsPmrKDgAw&iflsig=AINFCbYAAAAAYKAhHn2ANm0oA-UjZt3e_pvv1VdldF4P&oq=haroe+268+israel&gs_lcp=Cgdnd3Mtd2l6EAMyAggmOgIIADoICAAQxwEQowI6AgguOgUILhCTAjoICAAQxwEQrwE6BAgAEAo6BAguEAo6BAgAEB46CggAEMcBEK8BEBM6CAgAEBYQHhATOgUIIRCgAToECCEQFToHCCEQChCgAVDoP1iNe2CQgQFoAXAAeACAAbQBiAHIF5IBBDAuMjCYAQCgAQGqAQdnd3Mtd2l6&sclient=gws-wiz&ved=0ahUKEwiv1YzWqMzwAhXcDWMBHRrZAMAQ4dUDCAc&uact=5#"
            }
        ID = 
            {
                Israeli = No_Choice
                Swedish = "3-1924217-8"
            }
    }

(*
type Experience = {
    Job_Title : string
    Company_Name : string
    Period : Work_Period
    Location : string
    Description : seq<Paragraph_Line>
}

type Work_Type = 
    | With_Ongoing
    | No_Ongoing of string


type Work_Period = {
    End_Date : Work_Type
    Start_Date : string
}
*)

let job_title_0 = "Manager"
let company_name_0 =
    {
        Link_Title = "DV Hemtjänst i Umeå AB"
        Link = "https://www.dammvippanumea.se/"
    }
let period_0 = {
    Start_Date = "Oct 2018"
    End_Date = "Mar 2019" |> No_Ongoing
}
let Location_0 =
    {
        Link_Title = "Umeå, Sverige"
        Link = "https://www.google.se/maps/place/Ume%C3%A5,+Sverige/@63.8268562,20.1018798,11z/data=!3m1!4b1!4m5!3m4!1s0x467c4e1b68add7f9:0x4034506de8c8560!8m2!3d63.8258471!4d20.2630354"
    }
let Description_0 =
    seq[
        "DV Hemtjänst i Umeå AB (DammVippan Home Services in Umeå Ltd) is a company that is specialized in nursing, private home service, and home care."
    ]

let job_title_1 = "Social Worker in the Financial Assistance Department"
let company_name_1 =
    {
        Link_Title = "Malmö stad"
        Link = "https://malmo.se/"
    }
let period_1 = {
    Start_Date = "Mar 2019"
    End_Date = "Okt 2020" |> No_Ongoing
}
let Location_1 =
    {
        Link_Title = "Malmö, Sverige"
        Link = "https://www.google.se/maps?q=malm%C3%B6&sxsrf=ALeKk036NWQervj-8j3bS_T9_aU3ReuRlw:1621120357769&iflsig=AINFCbYAAAAAYKBjdfwKt1aMt9h4aPDb5qUkl_MXmASZ&gs_lcp=Cgdnd3Mtd2l6EAMyBAgjECcyBAgjECcyBAgjECcyBQguEMsBMggIABDHARCvATICCAAyAgguMgIILjICCAAyAggAOggIABDHARCjAjoECAAQQ1DjBFi_C2DBDWgAcAB4AIABygGIAd4GkgEFMC40LjGYAQCgAQGqAQdnd3Mtd2l6&uact=5&um=1&ie=UTF-8&sa=X&ved=2ahUKEwjKucf558zwAhWdEWMBHdSRDlQQ_AUoAXoECAEQAw"
    }
let Description_1 =
    seq[
        "Administrating state financed economical support."
        //" of the company concerning materials from external suppliers "
    ]

let job_title_2 = "Receptionist"
let company_name_2 =
    {
        Link_Title = "The Norman Tel Aviv"
        Link = "https://www.thenorman.com/"
    }
let period_2 = {
    Start_Date = "Jan 2021"
    End_Date = With_Ongoing
}
let Location_2 =
    {
        Link_Title = "Nachmani St 23-25, Tel Aviv-Yafo, 6579441"
        Link = "https://www.google.se/maps/place/The+Norman+Tel+Aviv/@32.0659877,34.7732923,17z/data=!3m1!4b1!4m8!3m7!1s0x151d4b7da2069071:0xe7b54e3473541390!5m2!4m1!1i2!8m2!3d32.0659877!4d34.775481"
    }
let Description_2 =
    seq[
        "Nestled on a picturesque city square, The Norman, the only luxury boutique hotel in Tel Aviv, lies in the heart of the White City; Tel Aviv’s world-famous UNESCO heritage site of historic Bauhaus architecture buildings"
    ]

(*
    {
        Job_Title : string
        Company_Name : Link
        Period : Work_Period
        Location : Link
        Description : seq<string>
    }
*)

let experiences = 
    seq[
        {
            Job_Title = job_title_0
            Company_Name = company_name_0
            Period = period_0
            Location = Location_0
            Description = Description_0
        }
        {
            Job_Title = job_title_1
            Company_Name = company_name_1
            Period = period_1
            Location = Location_1
            Description = Description_1
        }

        {
            Job_Title = job_title_2
            Company_Name = company_name_2
            Period = period_2
            Location = Location_2
            Description = Description_2
        }
        
    ]

(*
    type Project = {
        Project_Title : string
        Institution : string
        Details : seq<Paragraph_Line>
    }
*)

let project_title_1 = "PRTT ( Pre/Post repair Testing Tool) Ericsson"
let institution_1 = "Ericsson"
let details_1 =
    seq[
        "A widely used, extensive, test system in the Ericsson world, simulating real radio base station, including radio power measurement tests."
        "Syntronic AB delivers monthly software updates for this system."
    ]

let project_title_2 = "LAT ( Log Analysis Tool) Ericsson"
let institution_2 = "Ericsson"
let details_2 =
    seq[
        "Compared to PRTT, a newer and simpler test system, also widely used within the Ericsson world."
        "In short, this test system analyzes logs created from sensors on telecom equipment."
        "Syntronic AB deliver monthly software updates for this system."
    ]

let project_title_3 = "CLAT ( Cloud Log Analysis Tool) Ericsson"
let institution_3 = "Ericsson"
let details_3 =
    seq[
        "This under development test syste has basically the same function as LAT,"
        "but large parts of the software, instead, exists in the cloud, with the goal of minimizing extensive local software installment."
    ]

(*
    type Project = {
        Project_Title : string
        Institution : string
        Details : seq<string>
    }
*)

let projects =
    seq[
        {
            Project_Title = project_title_1
            Institution = institution_1
            Details = details_1
        }
        {
            Project_Title = project_title_2
            Institution = institution_2
            Details = details_2
        }
        {
            Project_Title = project_title_3
            Institution = institution_3
            Details = details_3
        }
    ]

(*
    type Extras = {
        Philosofy : Binary_Choice<string>
        Proud_Of : seq<Proudness>
        Strengths : seq<string>
        Languages : seq<string>
    }

    type Proudness = {
    Proudness_Url : string
    Proudness_Title : string
    Proudness_Description : string
}
*)

let proud_of = 
    [
        {
            Proudness_Url = "fas fa-music"
            Proudness_Title = "Musical"
            Proudness_Description = "A very good piano player"
        }

        {
            Proudness_Url = "fas fa-square-root-alt"
            Proudness_Title = "Mathematical"
            Proudness_Description = "Highest grade in Multivariable Calculus"
        }
    ]

(*
    type Language = {
        Language_name : string
        Rating : int
    }
*)

let languages = 
    seq[
        {
            Language_name = "Swedish"
            Rating = 100.0
        }
        {
            Language_name = "English"
            Rating = 90.0
        }
        {
            Language_name = "Hebrew"
            Rating = 75.0
        }
    ]

let programming_languages = 
    seq[
        {
            Language_name = "C#"
            Rating = 80.0
        }
        {
            Language_name = "F#"
            Rating = 85.0
        }
        {
            Language_name = "Javascript"
            Rating = 50.0
        }
        {
            Language_name = "MATLAB"
            Rating = 55.0
        }
    ]

(*
    type DayActivity = {
        Activity_TItle : string
        Percentage : float
    } 
*)

let extra_info_app_develop = "F# with elm architecture, React style F# frontend and Javascript backend)"
let extra_info_piano = "like to play classical style music, some klezmer and boogie woogie"

let daily_activities =
    seq[
        {
            Activity_Title = "Daytime job" |> Has_No_Extra_Description_Info
            Percentage = (8.0/24.0)
        } 
        {
            Activity_Title = ("Developing Elmish React Fable* apps or F# scripts to automate work tasks",extra_info_app_develop)
                             |> Has_Extra_Description_Info
            Percentage = 2.0/24.0
        }
        {
            Activity_Title = "Work out" |> Has_No_Extra_Description_Info
            Percentage = 2.0/24.0
        } 
        {
            Activity_Title = ("Play piano" ,"") |> Has_Extra_Description_Info
            Percentage = 1.0/24.0
        } 
        {
            Activity_Title = ("Chill", "watch TV, hang out with friends, and other stuff") |> Has_Extra_Description_Info
            Percentage = 4.0/24.0
        } 
        {
            Activity_Title = "Sleep" |> Has_No_Extra_Description_Info
            Percentage = 7.0/24.0
        } 
    ]

(*
    type Extras = {
        Philosofy : Binary_Choice<string>
        Proud_Of : seq<Proudness>
        Strengths : seq<string>
        Languages : seq<Language>
        Programming_Languages : seq<Language>
    }
*)

let strengths =
    seq[
        {
            Strength_Icon = "fas fa-brain"
            Strength_Descr = "Can easily focus"
        }
        {
            Strength_Icon = "far fa-handshake"
            Strength_Descr = "Collaborative"
        }
        {
            Strength_Icon = "fas fa-dumbbell"
            Strength_Descr = "Hard working"
        }
    ]

let extras =
    {
        Philosofy = "Something" |> Yes_Choice
        Proud_Of = proud_of
        Strengths = strengths 
        Languages = languages
        Programming_Languages = programming_languages
    }

(*
    type Education = {
        Education_TItle : string
        University : string
        Education_Period : Work_Period
    }

        type Work_Period = {
        End_Date : Work_Type
        Start_Date : string
    }

    type Link = {
    Link : string
    Link_TItle : string
    }
*)

let educations = 
    seq[
        {
            Education_TItle = "Bachelor of Science in Social Work"
            University = 
                {
                    Link = "https://www.umu.se/en/"
                    Link_Title = "Umeå University"
                }   
            Education_Period = 
                {
                    End_Date = "Aug 2018" |> No_Ongoing
                    Start_Date = "Aug 2014"
                }
        }
    ]

(*
    type Main_Model = {
        Basic : Basic_Info
        Experiences : seq<Experience>
        Projects : seq<Project>
        Extra_Info : Binary_Choice<Extras>
        Educations : seq<Education>
        Day_In_Life : seq<DayActivity>
    }
*)

let main_model =
    {
        Basic = basic_information
        Experiences = experiences
        Projects = projects
        Extra_Info = extras |> Yes_Choice
        Educations = educations
        Day_In_Life = daily_activities
    }

//let turnIntoFSharpHtml =
//    let input =
//        File.ReadAllText("htmlExample.txt")
//
//    let output =
//        GenerateHtmlFunctions.getFullHtmlInfo input
//        |> Async.RunSynchronously
//
//    let resultAsText =
//        output
//        |> Seq.map (fun itm ->
//            GenerateHtmlFunctions.HtmlProcessor.html_Info_Encoder itm
//        )
//        |> String.concat ",\n"
//
//    File.WriteAllText("htmlFSharp.json", resultAsText)
//
//    let fSharpCode =
//        GenerateHtmlFunctions.htmlInfo2FSharp output 0
//
//    let htmlELementListRegexExpr = 
//        new Regex("(?<=Html.).*(?=\s\[)")
//
//    let htmlElMatches = htmlELementListRegexExpr.Matches(fSharpCode)
//
//    let matchesAsListStr =
//        [0..htmlElMatches.Count - 1]
//        |> Seq.map (fun pos ->
//                htmlElMatches.[pos].Value
//            )
//        |> Seq.distinct
//        |> String.concat "\n"
//
//    let htmlPropsListRegexExpr = 
//        new Regex("(?<=prop.)\w+")
//
//    let htmlPropMatches = htmlPropsListRegexExpr.Matches(fSharpCode)
//
//    let propMatchesAsListStr =
//        [0..htmlPropMatches.Count - 1]
//        |> Seq.map (fun pos ->
//                htmlPropMatches.[pos].Value
//            )
//        |> Seq.distinct
//        |> Seq.filter (fun x -> x <> "children")
//        |> String.concat "\n"
//
//    File.WriteAllText("FSharpList.txt", matchesAsListStr + "\n\n" + propMatchesAsListStr )
//
//    File.WriteAllText("htmlFSharp.fs", fSharpCode)

let dir =
   $"{Directory.GetCurrentDirectory()}\..\Resume-CV-Design-N19-master\index.html"

let writeToHtml =
    
    File.WriteAllText(dir, (CV_Html_Template.template main_model).htmlStr)

writeToHtml





