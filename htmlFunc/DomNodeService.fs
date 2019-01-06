namespace Dom.Actions
open Dom.Elements
module DomainProperties = 

    let getNodeType nodeType =
        match nodeType with
        | TextNode t -> "Text"
        | ElementNode t -> t.TagName
        | CommentNode t -> "Comment"

    let rec walkNodes (domNodes:DomNode list) (indent:char list) (actionToDo:DomNode->unit) =
        match domNodes with
        | h::t-> 
                let indetSpace =  (indent |>  List.toArray |> System.String)
                printf "%s" indetSpace
                actionToDo h
                printf "%s-Children\r\n" indetSpace
                let newIndents = indent.[0]::indent
                walkNodes h.Children newIndents actionToDo
                walkNodes t indent actionToDo
        | [] -> ()