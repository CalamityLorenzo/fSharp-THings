module timezoneInfo 
open System
open System
open Suave.Logging
type TimeZoneInfo = {
        tzName:string;
        minDiff:float;
        localTime:string;
        utcOffset:float;}

 let getTimeInfo = 
    let tzs = TimeZoneInfo.GetSystemTimeZones();
    [
            for tz in tzs do
            // convert local time to the current timexpne
            let localTz = TimeZoneInfo.ConvertTime(DateTime.Now, tz)
            let fivePm = DateTime(localTz.Year, localTz.Month, localTz.Day, 17, 0,0)
            // get the differnece between now local and 5 pm local
            let minDifferences = (localTz-fivePm).TotalMinutes

            yield{
                tzName=tz.StandardName;
                minDiff=minDifferences;
                localTime =localTz.ToString("hh:mm tt");
                utcOffset=tz.BaseUtcOffset.TotalHours
            }
    ]