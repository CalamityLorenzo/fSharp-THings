namespace rec OrderTaking.Domain
open System
open OtherTypes.Model
//Product COde realted
// constraint:// starting with W then 4 digits
type WidgetCode = WidgetCode of string
//constraint starting with G then 3 digits
type GizmoCode  = GizmoCode of string
type ProductCode =
| WidgetCode of WidgetCode
| GizmoCode of GizmoCode
// Order quantity related
type UnitQuantity = UnitQuantity of int
type KilogramQuantity = KilogramQuantity of decimal

type OrderQuantity = 
 | Unit of UnitQuantity
 | Kilos of KilogramQuantity

type OrderId = OrderId of String
type OrderLineId = OrderLineId of int
type CustomerId = Undefined

type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type Price = Undefined
type BillingAmount = Undefined

type Order ={
    Id:OrderId
    CustomerId:CustomerId
    ShippingAddress:ShippingAddress
    BillingAddress:BillingAddress
    OrderLines:NonEmptyList<OrderLine>
    AmountToBill:BillingAmount
}

type OrderLine ={
    Id:OrderLineId
    OrderId:OrderId
    ProductCode:ProductCode
    OrderQuantity:OrderQuantity
    Price:Price
}
// Who can create the Verified Email?
type VerifiedCustomerEmail = private CustomerEmail of CustomerEmail 

type CustomerEmail =
  | Unverified of CustomerEmail
  | Verified of VerifiedCustomerEmail

///////////////////////////////////////////////
// Workfow types
///////////////////////////////////////////////
type UnvalidatedOrder = {
    OrderId:string
    CustomerInfo:string list
    ShippingAddress:string list
}

type PlaceOrderEvents = {
    AcknowledgementSent:string
    OrderPlaced:string
    BillableOrderPlaced:Boolean
}

type ValidationError={
    FieldName:string
    ErrorDescription:string
}
// can have maany different errorts
type PlaceOrderError =
    | ValidationError of ValidationError list  

 type PlaceOrder = UnvalidatedOrder->Result<PlaceOrderEvents, PlaceOrderError>

 type SendPasswordResetEmail = VerifiedCustomerEmail->string