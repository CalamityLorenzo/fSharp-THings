// Learn more about F# at http://fsharp.org

open System
open JsonFiles
open TimerModels
[<EntryPoint>]
let main argv =
    let setTimers = [
        {Name="set-1-1"; MillisecondRunTime=1450}
        {Name="set-1-2"; MillisecondRunTime=2000}
        ]
    let cycleTimers:CyclesContainer = {
        iterations=2;Timers=[
        {Name="cycle-1-1"; MillisecondRunTime=3030}
        {Name="cycle-1-2"; MillisecondRunTime=1010}]
    }

    //
    let s:SetsTimers list = [(NamedTimer setTimers.[0]);(NamedTimer setTimers.[1]);CyclesContainer cycleTimers]

    let setContainer={
        iterations=1;
        Timers=s;
    }
    printfn "argv %d" argv.Length
    let tG={
        Name= "My timers"
        Prepare= Some (HeaderTimer {Name="Prepare"; MillisecondRunTime=1800})
        Timers= [Sets setContainer]
        Cooldown= None
    }
    TimerFunctions.RunInstance tG
    0 // return an integer exit code
