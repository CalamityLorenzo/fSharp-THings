namespace ScratchOrder
module OrderTypes = 
    type CardNumber = CardNumber of string
    type WidgetCode = string
    type GizmoCode  = string
    type ProductCode = 
        |Widget of WidgetCode
        |Gizmo of GizmoCode
    type OrderLine = Undefined
    type CustomerInfo = Undefined
    type ShippingAddress = Undefined
    type BillingAddress = Undefined

    type Amount = Undefined

    type InvoiceId = InvoiceId of string
    type UnpaidInvoice ={
        InvoiceId:InvoiceId
    }

    type PaidInvoice = {
        InvoiceId:InvoiceId
    }
    // discrimated type, sharing a field
    type Invoice = 
       | Unpaid of UnpaidInvoice
       | Paid of PaidInvoice

    type Order = {
        CustomerInfo:CustomerInfo
        ShippingAddress:ShippingAddress
        BillingAddress:BillingAddress
        OrderLines:OrderLine list
        AmountToBill: Amount
     }


    type ProcessedOrder = Undefined
    type BillableOrderPlaced = Unknown
    type AcknowledgementSent = Undefined
    type OrderPlaced = Undefined

    type PlaceOrderEvents = { AcknowledgementSent:AcknowledgementSent; OrderPlaced:OrderPlaced; BillableOrderPlaced:BillableOrderPlaced }

    type UnvalidatedOrder = Undefined
    type ValidatedOrder = Undefined
    type ValidationError = {FieldName:string; ErrorDescription:string}
    // One type in One type out with error efffects and asychrony
    type ValidationResponse<'a> = Async<Result<'a, ValidationError list>>
    type ValidateOrder = UnvalidatedOrder-> Async<Result<ValidatedOrder,ValidationError list>>
    // or with our generic alias. This is just an alias. nothing more.
    type AValidateOrder = UnvalidatedOrder-> ValidationResponse<ValidatedOrder>

    // Output is several tings to be processed.
    type PlaceOrder = UnvalidatedOrder->PlaceOrderEvents



    