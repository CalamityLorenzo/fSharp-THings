namespace TimerModels
    open System
    type NamedTimer={Name:string; MillisecondRunTime:int;}

    // Can only have timers inside of it.
    type CyclesContainer = {iterations:int; Timers:NamedTimer list}
    
    // Particular type of Timer Aggregate
    type SetsTimers =
        | NamedTimer of NamedTimer
        | CyclesContainer of CyclesContainer
    
    type SetsContainer = {iterations:int; Timers:SetsTimers list}
    
    // Particular type of Timer Aggregate
    type TimerFunctions = 
        | TimerItem of NamedTimer
        | Cycle of CyclesContainer
        | Sets of SetsContainer
        | Empty

    type TimerHeader = HeaderTimer of NamedTimer
    
    type TimerGroup = {
         Name: string
         Prepare:TimerHeader option
         Timers:TimerFunctions list
         Cooldown:TimerHeader option
        }
        