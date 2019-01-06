namespace JsonFiles 
   open FSharp.Data
    module JsonProcessing = 
        // Layout our Json Provider file
        type SimpleJson = JsonProvider<""" { "name":"Paul", "town":"Tugsworth", "numberList":[1,2,3] } """> 
        let basic = 
            let simpleResult = SimpleJson.Parse(""" { "name":"Paul", "town":"Tugsworth", "numberList":[7,8] } """)
            simpleResult.NumberList |> Seq.isEmpty  |> printfn "%b"

        

