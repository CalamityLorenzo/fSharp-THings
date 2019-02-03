module Myfuncs
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let runwebServer argv = 
  let portNum =8080
    // Suave app config
  let cfg = 
        {
         defaultConfig with 
            bindings = [HttpBinding.createSimple HTTP "0.0.0.0" portNum;]
        }
    // diefin a siomple GET Route at an endpoint
  let app = 
       choose 
            [ GET >=> choose  
                [ path "/" >=> request (fun _ -> OK "<h1>Hello world from F#</h1>")]
            ]
  startWebServer cfg app
