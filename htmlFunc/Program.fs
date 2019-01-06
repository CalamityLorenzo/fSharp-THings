// Learn more about F# at http://fsharp.org

open System
open Dom.Elements

 
[<EntryPoint>]
let main argv =
    let basicHtml = @"<html>
        <body>
            <h1>Title</h1>
            <div id=""main"" class=""test"">
                <p>Hello <em>world</em>!</p>
            </div>
        </body>
    </html>"
    let charsInCharge = Seq.toList "This is the string"
    let Junk = ForwardParser.create basicHtml
    
    Parser.TraverseParser Junk
    0 // return an integer exit code