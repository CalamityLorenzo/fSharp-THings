namespace Dom.Elements
open System
open System.Linq.Expressions
open System.Collections.Generic

type AttrMap = Map<string,string>

type ElementInfo={
     TagName:string;  
     Attributes: AttrMap
}

type NodeType = 
| TextNode of string
| ElementNode of ElementInfo
| CommentNode of string

type DomNode = {
    Children:DomNode list
    NodeType:NodeType
}


// holds the string we are going to be parsing.    
// int for length means not enormous strings.
// We can only move forward
type ForwardParser =
    private {
        completeString:char list
        mutable pos:int
    }   
    with 
        // keeping the fields private, cos we have a mutable value
        static member create (stringToUse:string) ={completeString= Seq.toList stringToUse; pos=0}
        member this.Position = this.pos
        member this.characters = this.completeString
        member this.length =
         this.completeString.Length
        // Reads current position without consuming
        member this.next_char =
            let currentPosition = this.pos
            if(this.eof) then
                 None;
            else 
                 Some(this.completeString.[currentPosition])
        // Move the needle forward and consume the next xhar
        member this.consume_char = 
            if(this.eof) then
                 None;
            else 
                let currentPosition = this.pos
                this.pos <- currentPosition + 1
                this.next_char

        member this.eof = 
            this.pos>this.length-1
        member this.starts_with (str:string) = 
           let newString = System.String.Concat(Array.ofList(this.completeString.GetSlice(Some(this.pos), Some(this.length))))
           newString.StartsWith str
        member this.current_char = 
            this.completeString.[this.Position]

        member this.consumeWhile test =
            let mutable stringResult= []
            while not(this.eof) && test this.consume_char
                do
                stringResult <- this.current_char::stringResult     
            stringResult |> List.rev
        end


module Parser =
    type chrFunc<'T> = Char->'T
    let rec RecursiveTraversal (psr:ForwardParser)  =
        match psr.consume_char with
        | Some chr -> printfn "%c" chr
                      RecursiveTraversal psr 
        | None -> printf "END OF LINE"
                  ()
