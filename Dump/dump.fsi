// construction and desconstruction are really realyted.
// single case discrimated union
type CardNumber = | CardNumber of string

// This is OR'd
// Discrimated Union
type AppleVariety =
 | GoldenDelicous
 | GrannySmith
 | Gala
 
 // Numbers or chars, or FLAAAGS
 type FruitEnum = 
 | Apple = 1
 | Banana = 2
 | Cherry = 3

// records types are AND
 type FruitSalad = {
     Apple:AppleType
     Banana:BananaType
     Cherry:CherryType
 }

// discrinated unions must be uppercase
// F and C are not distinct. They are the same TempratureUNit, but dif sub-label
 type TempratureUnits =
    | Farenheit of int
    | Celscius of double
  
module tempValues = 
    let tempInF = Farenheit 27
    let tempInC = Celscius 0.1


let printTemp tempVal =
    match tempVal with
    | Farenheit f -> printf "FARENHIH %i" f
    | Celscius c -> printf "CELCISUS"