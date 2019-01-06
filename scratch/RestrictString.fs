namespace ModelShop

exception RestrictStringException of string
type RestrictString = private RestrictString of string 

type SpecialCode = SpecialCode of RestrictString

// 'Smart' constructor That's not a constructor...
module RestrictString =
  let Create(setVal:string)=
       if(setVal.StartsWith("M")) then
         Error (RestrictStringException("Must start with M"))
       else if ( setVal.Length < 6) then
         Error (RestrictStringException("Not long now"))
       else
        Ok (RestrictString setVal)
  let Unpack (RestrictString cs) = cs
