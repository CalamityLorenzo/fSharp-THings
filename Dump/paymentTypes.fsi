// single value dis unions
// Wrapper type, "wraps" a primitive, but it's not the primitve re-lablled, can be replaced with anything.
type ChequeNumber = 
    | ChequeNumber of int
type CardNumber = 
    | CardNumber of string
// Type disconri 
type CreditCardType =
    | Visa | Mastercard | Maestro | VisaDebit | AmericanExpress
// REcord Type (Algebraic)
type CreditCardInfo = {
    CardType:CreditCardType
    Number:CardNumber
}
// Discrim
type PaymentMethod = 
    | Cash
    | Cheque of ChequeNumber
    | Card of CreditCardInfo
// Single use discrim
type PaymentAmount  = 
    | PaymentAmount of decimal
// Discriminatged
type Currency = EUR | USD | GBP | DRA | ComparisonIdentity

// Record;
type Payment = {
    Amount:PaymentAmount
    Currency:Currency
    Method:PaymentMethod
}

type PersonName = {
    First:string
    Middle:string option
    Last:string 
}

module processor =
// deconstruct as parameter
    let getCardNo (CardNumber num) =
        printfn "%s number" num