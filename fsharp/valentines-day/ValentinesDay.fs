module ValentinesDay

// TODO: please define the 'Approval' discriminated union type
type Approval =
    | Yes
    | No
    | Maybe

// TODO: please define the 'Cuisine' discriminated union type
type Cuisine =
    | Korean
    | Turkish

// TODO: please define the 'Genre' discriminated union type
type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

// TODO: please define the 'Activity' discriminated union type
type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateMovie (g: Genre) : Approval =
    match g with
    | Romance -> Yes
    | _ -> No

let rateRestaurant (c: Cuisine) : Approval =
    match c with
    | Korean -> Yes
    | _ -> Maybe

let rateWalk (distance) : Approval =
    match distance with
    | l when l < 3 -> Yes
    | l when l < 5 -> Maybe
    | l -> No

let rateActivity (activity: Activity) : Approval =
    match activity with
    | BoardGame -> No
    | Chill -> No
    | Movie m -> rateMovie m
    | Restaurant r -> rateRestaurant r
    | Walk w -> rateWalk w
