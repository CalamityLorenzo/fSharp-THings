// Learn more about F# at http://fsharp.org

open System

open ScratchOrder.OrderTypes
open OrderTaking.Domain
open FSharpx.Collections
open OtherTypes.Model
open FSharpx.Collections
let getCardNo (CardNumber cardInfo) = cardInfo
let getInvoiceId (InvoiceId invoice)= invoice
let invoiceCheck chk =
    match chk with
    | Paid pd -> printfn "You have paid your invoice : %s" (getInvoiceId pd.InvoiceId)
    | Unpaid pa -> printfn "You owe-e-owe-e-owe %s" (getInvoiceId pa.InvoiceId)
let cardStuff = 
    let cardNo = CardNumber "1234"
    getCardNo cardNo |> printfn "The Card is %s" 
    // We have created Two types of invoice.
    // from the discrimated union definition NOT the base definition
    // fully typed variation is possible.
    let unpaid = Invoice.Unpaid {InvoiceId=  InvoiceId "1234"  }
    let paid = Paid { InvoiceId=  InvoiceId "Jungle globes"  }
    invoiceCheck unpaid
    invoiceCheck paid
    ()
let NonEmptyStuff = 
    let c = {First="mesage"; Rest=["One";"Two";"Three"]}
    let d = c.Add "My Bonny"
    for itm in d.List do
        printfn "%s" itm
    ()

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    cardStuff
    NonEmptyStuff
    
    0 // return an integer exit code
