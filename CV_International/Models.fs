namespace CV_International

module Models =

    type Binary_Choice<'a> = 
        | No_Choice
        | Yes_Choice of 'a

    type Identification = {
        Israeli : Binary_Choice<string>
        Swedish : string
    }

    type Link = {
        Link : string
        Link_Title : string
    }

    type Basic_Info = {
        Picture_Url : string
        Name : string
        Email : string
        Location : Link
        Telephone_Number : string
        Address : Link
        ID : Identification
    }

    type Work_Type = 
         | With_Ongoing
         | No_Ongoing of string


    type Work_Period = {
        End_Date : Work_Type
        Start_Date : string
    }

    type Strength = {
        Strength_Icon : string
        Strength_Descr : string
    }

    type Paragraph_Line = {
        Line : string
    }

    type Experience = {
        Job_Title : string
        Company_Name : Link
        Period : Work_Period
        Location : Link
        Description : seq<string>
    }

    type Project = {
        Project_Title : string
        Institution : string
        Details : seq<string>
    }

    type Activite_Desription = 
        | Has_Extra_Description_Info of BasicMsg: string * ExtendedMsg: string
        | Has_No_Extra_Description_Info of string

    type DayActivity = {
        Activity_Title : Activite_Desription
        Percentage : float
    } 

    type Proudness = {
        Proudness_Url : string
        Proudness_Title : string
        Proudness_Description : string
    }

    type Language = {
        Language_name : string
        Rating : float
    }

    type Extras = {
        Philosofy : Binary_Choice<string>
        Proud_Of : seq<Proudness>
        Strengths : seq<Strength>
        Languages : seq<Language>
        Programming_Languages : seq<Language>
    }

    type Education = {
        Education_TItle : string
        University : Link
        Education_Period : Work_Period
    }

    type Main_Model = {
        Basic : Basic_Info
        Experiences : seq<Experience>
        Projects : seq<Project>
        Extra_Info : Binary_Choice<Extras>
        Educations : seq<Education>
        Day_In_Life : seq<DayActivity>
    }


