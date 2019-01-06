namespace Tiles.Models
// body text of what ever it is we are displaying
type Content = Content of string

type PanelType = 
    | Link 
    | FreeContent
 
type PanelLinkType =
    | Link
    | Button
  
type PanelLinkInfo ={
    Url:string
    Text:string
    LinkType:PanelLinkType  
}

type PanelProperty ={
    PropertyName:string
    ConstraintValue:string option
}

type Panel = {
    Property: PanelProperty option
    Link:PanelLinkInfo option
    Type: PanelType
    Content:Content
}

type Tile={
    ContainerOrder:int
    PropertyName:string
    Panels:Panel list
}
type TileLayout = 
    | Vertical
    | Horizontal

type TileContainer = {
    Id:string
    Layout:TileLayout
    Tiles:Tile list
}