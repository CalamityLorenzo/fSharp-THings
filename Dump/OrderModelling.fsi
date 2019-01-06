

type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type OrderLine = Undefined
type Amount = Undefined


type Order = {
    CustomerInfo:CustomerInfo
    ShippingAddress:ShippingAddress
    BillingAddress:BillingAddress
    OrderLines:OrderLine list
    AmountToBill: Amount
}