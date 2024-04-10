module TisburyTreasureHunt

let getCoordinate ((_, coordinate): string * string): string =
    coordinate

let convertCoordinate (coordinate: string): int * char = 
    ((coordinate.[0] |> int) - ('0' |> int) , coordinate.[1] |> char)

let compareRecords ((_, c1): string * string) ((_, c2, _): string * (int * char) * string) : bool = 
    convertCoordinate (c1) = c2

let createRecord (azaraData: string * string) (ruiData: string * (int * char) * string) : (string * string * string * string) =
    if compareRecords azaraData ruiData then
        let (treasure, coordinate) = azaraData
        let ( location, _, quadrant) = ruiData
        (coordinate, location, quadrant, treasure)
    else
        ("","","","")
