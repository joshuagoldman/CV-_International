namespace CV_International.Html

open System
open System.Text.RegularExpressions

type Text_Prop_Existence = {
    Reg_Prop_Values : string
    Text_Prop : string
}
type Text_Prop_Exists =
    | Text_Prop_Does_Not_Exist of string
    | Text_Prop_Does_Exist of Text_Prop_Existence

type Is_Text_Prop = 
    | Yes_Text_Prop
    | No_Text_Prop

type ChildrenOption = 
    | Yes_Is_Children of seq<string>
    | Is_Not_Children of string * Is_Text_Prop

type IStyleAttribute =
    abstract member styleStr: string

type IProp =
    abstract member prop: ChildrenOption

type IHtml = 
    abstract member htmlStr: string

type StyleConv (stylestr: string) =
   interface IStyleAttribute with
    member this.styleStr = stylestr

type HtmlConv (htmlstr: string) =
   interface IHtml with
    member this.htmlStr = htmlstr

type PropConv (prop: ChildrenOption) =
   interface IProp with
    member this.prop = prop

module HtmlFunctions =
    let childObjects ( props : seq<IProp> ) =
        props
        |> Seq.choose (fun prop ->
            match prop.prop with
            | Yes_Is_Children htmlVal ->
                Some htmlVal
            | Is_Not_Children _ ->
                None)
        |> function
            | res when (res |> Seq.length) <> 0 ->
                let result =
                    res
                    |> Seq.collect (fun c -> c)
                    |> String.concat "\r\n"
                Some result
            | _ -> None

    let find_text_prop (prop_infos : seq<string * Is_Text_Prop> ) =
        let reg_prop_vals = 
            prop_infos
            |> Seq.choose (fun (txt,choice) ->
                    match choice with
                    | Is_Text_Prop.Yes_Text_Prop ->
                        None
                    | _ -> Some txt
                )
            |> String.concat " "
        prop_infos
        |> Seq.tryPick (fun (txt,choice) ->
                match choice with
                | Is_Text_Prop.Yes_Text_Prop ->
                    Some txt
                | _ -> None
            )
        |> function
            | res when res.IsSome ->
                {
                    Reg_Prop_Values = reg_prop_vals
                    Text_Prop = res.Value
                }
                |> Text_Prop_Does_Exist
            | _ -> 
                reg_prop_vals
                |> Text_Prop_Does_Not_Exist
    
    let propStrings ( props : seq<IProp> ) =
        props
        |> Seq.choose (fun prop ->
            match prop.prop with
            | Yes_Is_Children _ ->
                None
            | Is_Not_Children (htmlVal,is_txt_prop) ->
                Some (htmlVal,is_txt_prop))
        |> function
            | res when (res |> Seq.length) <> 0 ->
                res
                |> find_text_prop
                |> Some
            | _ -> None

    let rowRegex = new Regex("(?<=\n)(.|.)*(?=\n)");

    let chunkRegex = new Regex("(?<=\n)(\n|.)*(?=\n)")

    let matchesAll str =
        let matches = rowRegex.Matches(str)

        let result =
            [0..matches.Count - 1]
            |> Seq.map (fun pos ->
                matches.[pos].Value)
        result

    let chunkMatch str =
        let matchVal = chunkRegex.Match(str).Value

        matchVal

    let replaceStr ( str : string ) matchVal =
        let result = 
            str.Replace(matchVal, "     " + matchVal)

        result

    let stringValue props ( name : string ) =
        let result =
            match (props |> childObjects) with
            | Some childrenValues ->
                match (props |> propStrings) with
                | Some vals ->
                    match vals with
                    | Text_Prop_Does_Not_Exist propValues ->
                        let resultStr =
                            String.Format(
                                "<{0} {1}>\n{2}\n</{0}>",
                                name,
                                propValues,
                                childrenValues
                        )
    
                        resultStr
                    | Text_Prop_Does_Exist info ->
                        let resultStr =
                            String.Format(
                                "<{0} {1}>{2}\n{3}\n</{0}>",
                                name,
                                info.Reg_Prop_Values,
                                info.Text_Prop,
                                childrenValues
                        )

                        resultStr
                | _ ->
                    let resultStr =
                        String.Format(
                            "<{0}>\n{1}\n</{0}>",
                            name,
                            childrenValues
                    )
    
                    resultStr
            | _ ->
                match (props |> propStrings) with
                | Some vals ->
                    match vals with
                    | Text_Prop_Does_Not_Exist propValues ->
                        let resultStr =
                            String.Format(
                                "<{0} {1}></{0}>",
                                name,
                                propValues
                        )
    
                        resultStr
                    | Text_Prop_Does_Exist info ->
                        let resultStr =
                            String.Format(
                                "<{0} {1}>{2}</{0}>",
                                name,
                                info.Reg_Prop_Values,
                                info.Text_Prop
                        )

                        resultStr
                | _ ->
                    String.Format(
                        "<{0}/>",
                        name
                    )
    
        new HtmlConv(result) :> IHtml
      

module Html =
    let none = new HtmlConv("") :> IHtml

    let html (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "html"

    let a (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "a"
    
    let head (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "head"
    
    let meta (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "meta"
    
    let title (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "title"
    
    let link (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "link"
    
    let script (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "script"
    
    let body (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "body"
    
    let div (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "div"
    
    let img (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "img"
    
    let p (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "p"
    
    let ul (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "ul"
    
    let li (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "li"
    
    let i (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "i"
    
    let br (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "br"
    
    let span (props: seq<IProp>) : IHtml =
        HtmlFunctions.stringValue props "span"

module prop =
    let children (htmls: seq<IHtml>) : IProp =
        let htmlsAsString =
            htmls
            |> Seq.map (fun x -> x.htmlStr)
        new PropConv(htmlsAsString|> Yes_Is_Children) :> IProp
    
    let style (styles: seq<IStyleAttribute>) : IProp =
        let stylesAsString =
            styles
            |> Seq.map (fun x -> x.styleStr)
            |> String.concat " "
        new PropConv((" "+ stylesAsString,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let style_html (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "style=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp
    
    let className (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "class=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let lang (className: string) : IProp =
         let htmlProp = 
             String.Format(
                 "lang=\"{0}\"",
                 className
             )
         new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let charset (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "charset=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let text (className: string) : IProp =
        new PropConv((className,Is_Text_Prop.Yes_Text_Prop)|> Is_Not_Children) :> IProp

    let rel (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "rel=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let href (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "href=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let src (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "src=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp

    let alt (className: string) : IProp =
        let htmlProp = 
            String.Format(
                "alt=\"{0}\"",
                className
            )
        new PropConv((htmlProp,Is_Text_Prop.No_Text_Prop)|> Is_Not_Children) :> IProp
module style =
    let color (chosenColor : string) : IStyleAttribute =
        let htmlStyle = 
            String.Format(
                "color=\"{0}\"",
                chosenColor
            )
        new StyleConv(htmlStyle) :> IStyleAttribute

    let margin (chosenColor : int) : IStyleAttribute =
        let htmlStyle = 
            String.Format(
                "margin={0}",
                (chosenColor |> string)
            )
        new StyleConv(htmlStyle) :> IStyleAttribute

    let width (chosenWidth : string) : IStyleAttribute =
        let htmlStyle = 
            String.Format(
                "margin={0}",
                (chosenWidth |> string)
            )
        new StyleConv(htmlStyle) :> IStyleAttribute
    