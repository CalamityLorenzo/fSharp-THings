// Learn more about F# at http://fsharp.org
open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames
open Microsoft.FSharp.Data.UnitSystems.SI.UnitSymbols
open System
open ModelShop
open PrivateConstructors
let RestrictStringResult res =
     match res with 
     | Ok ok -> RestrictString.Unpack ok
     | Error (e:Exception) -> e.Message

[<EntryPoint>]
let main argv =
    let restrictedStr = RestrictString.Create "M1234as"
    printfn "%s" (RestrictStringResult restrictedStr)
    let notChecked = UnverifiedEmaiil "Palace@home"
    let isChecked = CheckEmail "pill@c.com"
    0 // return an integer exit code
