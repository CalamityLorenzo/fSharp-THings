module rec TimerFunctions
    open TimerModels
    open System.Timers
    let timerObject = new Timer(Interval=10.0)
    
    let RunTimer (timer:NamedTimer) =
        printf "Timer: %s" timer.Name
        let mil = timer.MillisecondRunTime
        System.Threading.Thread.Sleep(mil)
    
    let runHeader timerHeader = 
        match timerHeader with
        | Some (HeaderTimer tHeader)-> RunTimer tHeader
        | None -> ()

    let runBodyTimers timerFuncs = 
        let rec doTimer timerF =  
          match timerF with
            | TimerItem  tmr-> RunTimer tmr
                               printfn "\t-Done!"
            | Sets set -> RunSet set; printfn "\t-Set Done!"
            | Cycle cyc -> RunCycle cyc; printfn "\t-Cycle Done!"
            | Empty -> ()
        for timer in timerFuncs do
            doTimer timer

    let RunCycle (cycle:CyclesContainer) =
       printfn "cycle : %d" cycle.iterations
       let mutable counter = cycle.iterations
       while counter > 0 do
            printfn "\titeration : %d" cycle.iterations
            counter <- counter-1
            for timer in cycle.Timers do
            RunTimer timer
    
    let rec RunSet (set:SetsContainer) = 
       let rec setTimer (timerF:SetsTimers ) =  
          match timerF with
            | NamedTimer  tmr-> RunTimer tmr
            | CyclesContainer cyc -> RunCycle cyc; printfn "\t-Cycle Done!"
       printfn "set : %d" set.iterations
       let mutable counter = set.iterations
       while counter > 0 do
            printfn "\titeration : %d" set.iterations
            counter <- counter-1
            for timer in set.Timers do
            setTimer timer

    let RunInstance timerContainer =
        printfn "%s" timerContainer.Name
        runHeader timerContainer.Prepare
        runBodyTimers timerContainer.Timers
        runHeader timerContainer.Cooldown