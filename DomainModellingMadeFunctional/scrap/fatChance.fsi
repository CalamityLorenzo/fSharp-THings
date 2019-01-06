type personName = { First:string; Middle:string option;  Last:string }
let notMe = { First = "Paul" ;  Middle="Christopher" Last="Hello"}
let me = { First = "Paul" ; Last="Hello" }

let printName (p:personName) =
    match p.Middle with
    | Some m -> printfn "Complete Name %s %s %s" p.First m p.Last
    | None -> printfn "No Middle Name : SHOCKER"