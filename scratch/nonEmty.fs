namespace rec OtherTypes.Model

// A list can be represented as always having at least one entry.
// I don't know why though. something about self-documenting
type NonEmptyList<'a> ={
    First:'a
    Rest:'a list
} with //https://fsharpforfunandprofit.com/posts/type-extensions/
        // Added with attaching funcations, can also be done optionally,can also be done in a different file too
    member this.Add newEntry = NonEmptyList.Add newEntry this
    member this.List = NonEmptyList.List this

module NonEmptyList =
    // Add a new entry
    let Add newEntry lst = 
        {
            First=newEntry
            Rest=lst.First::lst.Rest
        }
     // Return all of it as a list
    let List lst = lst.First::lst.Rest