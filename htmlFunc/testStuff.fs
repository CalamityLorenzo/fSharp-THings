namespace TestAreaDump 
open Dom.Elements
open Dom.Actions
// just create some nodes, and do a thing at the end where we walk the values
// Creation of algebraic types. We can create this based on input methods. thiqs is nice thing.
module v1 =
    let textNode = NodeType.TextNode "ho ho ho"
    let d2 = {
        Children=[]
        NodeType=TextNode "I remember when"
    }
    let d3 = {
        Children=[]
        NodeType=ElementNode{TagName="p"; Attributes = Map.empty}
    }
    let d4 = {
        Children=[]
        NodeType=CommentNode "Dont stand so close to me"    
        }
    let div = {
        Children=[]
        NodeType=NodeType.ElementNode{TagName="span";Attributes=["id", "fresno";"Clara", "bell"]|>Map.ofList}
    }
    let d5 = {
        Children=[div;d2;d3;d4]
        NodeType= NodeType.TextNode "tHEY DRIVE crazies"
    }
    // for the DomainNode, display the names
    let displayName = fun dn->printfn "%s" (DomainProperties.getNodeType dn.NodeType)
    DomainProperties.walkNodes [div;d2;d3;d4;d5] [' ']  displayName