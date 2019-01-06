namespace rec OtherTypes.Model

// A list can be represented as always having at least one entry.
// I don't know why though.
type NonEmptyList<'a> ={
    First:'a
    Rest:'a list
} with
    member this.Add newEntry = NonEmptyList.Add newEntry this
    member this.List = NonEmptyList.List this

module NonEmptyList =
    let Add newEntry lst = 
        {
            First=newEntry
            Rest=lst.First::lst.Rest
        }
    let List lst = lst.First::lst.Rest

