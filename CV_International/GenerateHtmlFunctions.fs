module CV_International.GenerateHtmlFunctions

open System
open System.IO
open Thoth.Json.Net

module HtmlProcessor =
    type Msg<'Event> =
        | Append of 'Event
        | CurrentState of AsyncReplyChannel<seq<'Event>>

    type EventStore<'Event> = {
        Get : unit -> seq<'Event>
        Append : 'Event -> unit
    }

    type Prop_Value = 
        | Is_Int of int
        | Is_String of string
        | Is_Float of float

    type Html_Property = {
        Prop_Name : string
        Prop : Prop_Value
    }

    type Html_Info = {
        Name : string
        Vertical_Levels : seq<int>
        Properties : seq<Html_Property>
    }

    let prop_val_converter (prop_val : Prop_Value) =
        match prop_val with
        | Prop_Value.Is_String str ->
            Encode.string str
        | Prop_Value.Is_Float fl ->
            Encode.float fl
        | Prop_Value.Is_Int i ->
            Encode.int i

    let property_encoder ( prop : Html_Property ) =
        Encode.object[
            "Name", Encode.string prop.Prop_Name
            "Value", prop_val_converter prop.Prop
        ]

    let propArray_encoder ( props : seq<Html_Property> ) =
        props
        |> Seq.map (fun prop ->
            property_encoder prop
        )
        |> Seq.toArray
        |> Encode.array

    let levelsEncoder (levels : seq<int> ) =
        levels
        |> Seq.map (fun level ->
                Encode.int level
            )
        |> Seq.toArray
        |> Encode.array

    let html_Info_Encoder ( info : Html_Info ) =
        Encode.object [
                "Name", Encode.string info.Name
                "Vertical_Level", levelsEncoder info.Vertical_Levels
                "Properties", propArray_encoder info.Properties
        ]
        |> Encode.toString 3


    let initialize () : EventStore<'Event> =
        let agent =
            MailboxProcessor.Start (fun inbox ->
                let rec loop state = async {
                    let! msg = inbox.Receive()

                    match msg with
                    | Append newState ->
                        let newStateSeq =
                            [newState]
                            |> Seq.append state
                        return! loop newStateSeq
                    | CurrentState reply ->
                        reply.Reply state

                        return! loop state
                }
                loop Seq.empty
            )

        let append event =
            agent.Post (Append event)

        let get () =
            agent.PostAndReply(CurrentState)

        {
            Get = get
            Append = append 
        }

let htmlTemplate ( htmlName : string ) =
    String.Format(
        "let {0} (props: seq<IProp>) : IHtml =
    HtmlFunctions.stringValue props \"{0}\"",
        htmlName
    )

let propTemplate ( strVal : string ) =
    String.Format(
        "let {0} (className: string) : IProp =
        let htmlProp = 
            String.Format(
                \"{0}=\\\"{{0}}\\\"\",
                className
            )
        new PropConv((htmlProp,Is_Not_Children)) :> IProp",
        strVal
    )

let htmls =
    seq[
        "html"
        "head"
        "meta"
        "title"
        "link"
        "script"
        "body"
        "div"
        "img"
        "p"
        "ul"
        "li"
        "i"
        "br"
        "span"
    ]

let props =
    seq[
        "lang"
        "charset"
        "text"
        "rel"
        "href"
        "src"
        "className"
        "alt"
        "style"
    ]

let writeToFile strVal =
    File.WriteAllText("test.txt", strVal)

let generateHtmls =
    htmls
    |> Seq.map (fun element ->
        element |> htmlTemplate)
    |> String.concat "\n\n"

let generateProps =
    props
    |> Seq.map (fun element ->
        let result =
             element |> propTemplate

        result
       )
    |> String.concat "\n\n"

let generateHtml =
    (generateHtmls + "\n\n" + generateProps)
    |> writeToFile

open System.Text.RegularExpressions

let allOpeningTagsRegex =
    new Regex("<\w+(.|\n)*?>")



let htmlElementRege space elName =
    String.Format(
        "{0}\<{1}.*>(.|\n)*?>\n{0}<\/{1}>",
        space,
        elName
    )
    |> fun x -> new Regex(x)

type ChildrenOptions =
    | No_Children
    | Yes_Children

type tagType = 
    | Opening_Tag
    | End_Tag

type HtmlAttributeInfo = {
    Attr_Value : string
    Attr_Name : string
}

let isOpenOrCloseTag ( name : string ) tag =
    let openTagExpr =
        String.Format(
            "<{0}(.|\n)*?",
            name
        )

    let regexExpr = new Regex(openTagExpr)
    if regexExpr.Match(tag).Success
    then
        Opening_Tag
    else
        tagType.End_Tag

let rec filteringFunc allMatchesWithTagType =
    let allMatchesAsString =
        allMatchesWithTagType
        |> Seq.map (fun (m,_) -> m)
        |> String.concat ""

    allMatchesWithTagType
    |> Seq.indexed
    |> Seq.tryPick (fun (indx,(m,tagType)) ->
        let tempRegexExpr =
            new Regex(m)
        let isNotDistinct = 
            tempRegexExpr.Matches(allMatchesAsString).Count > 1

        match isNotDistinct with
        | true ->
            Some (indx,(m,tagType))
        | false ->
            None
    )
    |> function
        | res when res.IsSome ->
            allMatchesWithTagType
            |> Seq.indexed
            |> Seq.filter (fun (indx,_ ) ->
                let (indxComp,_) = res.Value
                indx <> indxComp)
            |> Seq.map (fun (_,y) -> y)
            |> filteringFunc 
        | _ ->  allMatchesWithTagType

let getChunkMatchExpr endPos ( allMatches : MatchCollection ) name =
                
    let allMatchesWithTagType =
        [0..endPos]
        |> Seq.map (fun pos ->
            allMatches.[pos].Value
        )
        |> Seq.map (fun m ->
            let tagType = isOpenOrCloseTag name m
            (m,tagType)
        )

    let allMatchesFiltered =
        allMatchesWithTagType
        |> Seq.map (fun (x,_) -> x)
        |> Seq.toArray

    let newEndPos = 
        allMatchesFiltered |> Seq.length 
    
    let str =
        allMatchesFiltered.[0..newEndPos - 1]
        |> String.concat "(.|\n)*?"

    new Regex(str)

let textPropRegex = new Regex("(?<=>).*(?=<)")

let addIfTextPropMatch sequence elementAsString = 
    if textPropRegex.IsMatch(elementAsString)
    then
        {
            HtmlProcessor.Prop_Name = "text"
            HtmlProcessor.Html_Property.Prop = textPropRegex.Match(elementAsString).Value  |> HtmlProcessor.Is_String
        }
        |> fun x -> seq[x]
        |> Seq.append sequence
    else
        sequence

let turnElementIntoPropType ( name : string ) elementAsString =
    let attributeNamesRegexExpr =
        let str =
            String.Format(
                "(?<={0}(.|\n)*)\w+(?=\=\")",
                name
            )
        new Regex(str)

    let attributeValuesRegexExpr =
        let str =
            String.Format(
                "(?<={0}(.|\n)*\=)(.|\n)*?\"(?=\s|>)",
                name
            )
        new Regex(str)
    
    let attributeNamesMatches = attributeNamesRegexExpr.Matches(elementAsString)
    let attributeValuesMatches = attributeValuesRegexExpr.Matches(elementAsString)

    let result =
        match (attributeNamesMatches.Count = attributeValuesMatches.Count) with
        | true ->
            let attributes =
                [0..attributeNamesMatches.Count - 1]
                |> Seq.map (fun pos ->
                    {
                        HtmlProcessor.Prop_Name = attributeNamesMatches.[pos].Value
                        HtmlProcessor.Html_Property.Prop = attributeValuesMatches.[pos].Value  |> HtmlProcessor.Is_String
                    })

            attributes
        | _ ->
            seq[]

    result
    

let getNewChunkToInvestigate ( allSimilarTagsMatches : MatchCollection ) 
                               chunk
                               endTagPos =
    let str =
        [1..endTagPos - 1]
        |> Seq.map (fun pos ->
            allSimilarTagsMatches.[pos].Value)
        |> String.concat("(.|\n)*?")
        |> fun x ->
            let subExpr =
                String.Format(
                    "(?<={0})(.|\n)*?{1}(.|\n)*?(?={2})",
                    allSimilarTagsMatches.[0],
                    x,
                    allSimilarTagsMatches.[endTagPos]
                )
            subExpr

    let expr = new Regex(str)

    expr.Match(chunk).Value

let getNewChunkAfterPreviousToInvestigate ( allSimilarTagsMatches : MatchCollection ) 
                                            chunk
                                            endTagPos =
    let str =
           [0..endTagPos]
           |> Seq.map (fun pos ->
               allSimilarTagsMatches.[pos].Value)
           |> String.concat("(.|\n)*?")

    let expr = new Regex(str)

    let unwantedPart = expr.Match(chunk).Value

    let wantedPart = chunk.Replace(unwantedPart,"")

    wantedPart

let getEndTagPosOpt ( allSimilarTagsMatches : MatchCollection ) 
                      name =
    match allSimilarTagsMatches.Count with
    | 1 -> 0 |> Some
    | _ ->
        [0..allSimilarTagsMatches.Count - 1]
        |> Seq.tryPick (fun curr_end_pos ->
            let allSimilarTagsMatchesUpToCurrent = 
                [0..curr_end_pos]
                |> Seq.map (fun pos ->
                    isOpenOrCloseTag name allSimilarTagsMatches.[pos].Value)

            let numberOfOpeningTags =
                allSimilarTagsMatchesUpToCurrent
                |> Seq.choose (fun tag ->
                    match tag with
                    | Opening_Tag -> Some tag
                    | _ -> None)
 
            match (isOpenOrCloseTag name allSimilarTagsMatches.[curr_end_pos].Value) with
            | Opening_Tag -> None
            | _ ->          
                let numberOfClosingTags =
                    allSimilarTagsMatchesUpToCurrent
                    |> Seq.choose (fun tag ->
                            match tag with
                            | End_Tag -> Some tag
                            | _ -> None)
                         
                match (numberOfOpeningTags |> Seq.length) with
                | 1 -> 1 |> Some
                | _ ->
                    let equalTagTypes =
                        (numberOfOpeningTags |> Seq.length) = (numberOfClosingTags |> Seq.length)
                    match equalTagTypes with
                    | true ->
                        curr_end_pos |> Some
                    | _ -> None)

let matchesAll str =
    let regexExpr = new Regex("(?<=prop.children\[\s+)(.|\n)*(?=\])")
    let matches = regexExpr.Matches(str)

    let result =
        [0..matches.Count - 1]
        |> Seq.map (fun pos ->
            matches.[pos].Value)
    result

let chunkRegex = new Regex("(?<=\n)(\n|.)*(?=\n)")

let chunkMatch str =
    let matchVal = chunkRegex.Match(str).Value

    matchVal

(*
    type Html_Info = {
        Name : string
        Processor : EventStore<Html_Info>
        Vertical_Level : int
        Horizontal_Level : int
        Properties : seq<Html_Property>
    }
*)
            
let rec html2FSharpConv ( levels : seq<int> )
                        ( proc : HtmlProcessor.EventStore<HtmlProcessor.Html_Info>)
                        ( chunk : string ) = async {
    let allOpenTagsExpr = 
        new Regex("<\w(.|\n)*?>")
        
    let firstOpenTagMatch = 
        allOpenTagsExpr.Match(chunk).Value

    let nameRegexExpr =
        new Regex("(?<=\<)\w+(?=(.|\n)*\>)")
                
    let name = nameRegexExpr.Match(firstOpenTagMatch).Value

    let allSimilarTagsExpr =
        let str =
            String.Format(
                "<\/{0}>|<{0}(.|\n)*?>",
                name
            )

        new Regex(str)

    let allSimilarTagMatches = 
        allSimilarTagsExpr.Matches(chunk)

    let endTagPosOpt =
        getEndTagPosOpt 
            allSimilarTagMatches
            name

    match endTagPosOpt with
    | Some endTagPos ->

        let newChunkToInvestigate =
            getNewChunkToInvestigate 
                    allSimilarTagMatches
                    chunk
                    endTagPos

        let newChunkAfterPreviousToInvestigate =
            getNewChunkAfterPreviousToInvestigate 
                                allSimilarTagMatches
                                chunk
                                endTagPos

        let validHtmlRegexExpr = 
            new Regex("<\w(.|\n)*?>")

        let NewChunk = validHtmlRegexExpr.Match(newChunkToInvestigate).Success
        let NewSubsequentChunk = validHtmlRegexExpr.Match(newChunkAfterPreviousToInvestigate).Success

        let props =
            match not(NewChunk) && newChunkToInvestigate <> "" with
            | true ->
                turnElementIntoPropType name allSimilarTagMatches.[0].Value
                |> Seq.append
                    [
                        {
                            HtmlProcessor.Prop_Name = "text"
                            HtmlProcessor.Prop = "\"" + newChunkToInvestigate + "\"" |>  HtmlProcessor.Is_String
                        }
                    ]
            | false ->
                turnElementIntoPropType name allSimilarTagMatches.[0].Value

        let curr_html_info =
            {
                HtmlProcessor.Name = name
                HtmlProcessor.Vertical_Levels = levels
                HtmlProcessor.Properties = props
            }

        proc.Append curr_html_info

        let newInnerIteration =
            if NewChunk
            then
                let lastLevel = levels |> Seq.last
                let nestedLevels =
                    Seq.append levels [lastLevel]
                
                
                html2FSharpConv
                        nestedLevels
                        proc
                        newChunkToInvestigate
                |> Some
            else 
                None

        let newSubsequentIteration =
            if NewSubsequentChunk
            then
                let lastPos = 
                    levels
                    |> Seq.indexed
                    |> Seq.last
                    |> fun (indx,_) -> indx
                let subsequentLevels =
                    levels
                    |> Seq.indexed
                    |> Seq.map (fun (indx,level) ->
                        if indx = lastPos
                        then
                            level + 1
                        else level)
                
                html2FSharpConv
                            subsequentLevels
                            proc
                            newChunkAfterPreviousToInvestigate
                |> Some
            else
                None
            
        let parallellAsyncActions =
            seq[
                newInnerIteration
                newSubsequentIteration
            ]
            |> Seq.choose id
            |> function
                | res when (res |> Seq.length <> 0)->
                    res
                    |> Async.Parallel
                    |> Async.RunSynchronously
                    |> Seq.iter (fun x -> x)
                | _ -> 
                    ()

        parallellAsyncActions


    | _ ->
        ()
}

let getFullHtmlInfo htmlPage = async {
    let proc = HtmlProcessor.initialize()
    
    let initialLevels = seq[0]
        
    do!
        html2FSharpConv
                initialLevels
                proc
                htmlPage
    
    return(proc.Get ())
}

type ParentAndKidz = {
    Parent : HtmlProcessor.Html_Info
    Descendants : seq<HtmlProcessor.Html_Info>
}

type PersonOptions =
    | Person_Has_Descendants of ParentAndKidz
    | Person_Is_Not_Parent of HtmlProcessor.Html_Info

let propsAsString ( info : HtmlProcessor.Html_Info ) =
    let result =
        info.Properties
        |> Seq.map (fun prop ->
                let propVal =
                    match prop.Prop with
                    | HtmlProcessor.Is_Float v -> v |> string
                    | HtmlProcessor.Is_String v -> v
                    | HtmlProcessor.Is_Int v ->v |> string

                String.Format(
                    "prop.{0} {1}",
                    prop.Prop_Name.Replace("class", "className"),
                    propVal.Replace("\n","").Trim()
                )
            )
        |> String.concat "
    "

    result

let rec htmlInfo2FSharp ( infos : seq<HtmlProcessor.Html_Info> ) horizontalLevel =
    
    let infoSameVertical =
        infos
        |> Seq.filter (fun info ->
                (info.Vertical_Levels |> Seq.length) = horizontalLevel + 1
            )
        |> Seq.sortBy (fun info ->
                info.Vertical_Levels
                |> Seq.last
            )

    let possibleDescendantsOpt ( info : HtmlProcessor.Html_Info ) =
        infos
        |> Seq.choose (fun info_comp ->
                match (info_comp.Vertical_Levels |> Seq.length) >
                      (info.Vertical_Levels |> Seq.length) with
                | true ->
                    let infoCompareLevelsUpUntil =
                        info_comp.Vertical_Levels
                        |> Seq.toArray
                        |> fun info_comp_arr ->
                            info_comp_arr.[0..info_comp_arr |> Seq.length |> fun x -> x - 2]
                            |> Array.toSeq
                    let isAKid =
                        Seq.zip info.Vertical_Levels infoCompareLevelsUpUntil
                        |> Seq.forall (fun (level,level_comp) ->
                                level = level_comp
                            )

                    match isAKid with
                    | true ->
                        Some info_comp
                    | false ->
                        None
                | false -> 
                    None
            )
        |> function
            | res when (res|> Seq.length) > 0 ->
                Some res
            | _ -> None

    let allParentWithKidzOpt =
        infoSameVertical
        |> Seq.map (fun info ->
                let result =
                    possibleDescendantsOpt info
                
                match result with
                | Some descendants ->
                    {
                        Parent = info 
                        Descendants = descendants
                    }
                    |> Person_Has_Descendants
                | _ -> 
                    info
                    |> Person_Is_Not_Parent
            )

    let finalHtml =

        allParentWithKidzOpt
        |> Seq.map (fun element_type ->
                match element_type with
                | Person_Is_Not_Parent info ->
                    let props = 
                        if propsAsString info = ""
                        then ""
                        else "
    "                           + propsAsString info

                    let htmlElementAsString =
                        String.Format(
                            "Html.{0} [{1}
]",
                            info.Name,
                            props
                        )

                    htmlElementAsString
                | Person_Has_Descendants parent_with_possible_descendants ->
                    let descendants =  
                        htmlInfo2FSharp parent_with_possible_descendants.Descendants (horizontalLevel + 1)
                        |> fun str -> (str : string ).Split '\n' 
                        |> String.concat "\n        "
                    
                    let props = 
                        if propsAsString parent_with_possible_descendants.Parent = ""
                        then ""
                        else "
    "                           + propsAsString parent_with_possible_descendants.Parent 
                    let htmlString =
                        String.Format(
                            "Html.{0} [{1}
    prop.children [
        {2}
    ]
]",
                            parent_with_possible_descendants.Parent.Name,
                            props,
                            descendants
                        )

                    htmlString

            )
        |> String.concat "
"

    finalHtml

generateHtml
            
            
        


            

             



    

    



