// Learn more about F# at http://fsharp.org
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

open Myfuncs
open System
open timezoneInfo

[<EntryPoint>]
let main argv =
    
    printfn "%s" getTimeInfo.Head.tzName
    runwebServer argv
    0 // return an integer exit code
