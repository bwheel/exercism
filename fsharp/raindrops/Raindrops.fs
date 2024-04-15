module Raindrops


let convert (number: int): string = 
    [(3, "Pling");(5,"Plang");(7,"Plong")]
        |> List.choose (fun (f, txt) -> if number % f = 0 then Some(txt) else None )
        |> fun e -> match e with
                                    | [] -> number |> string
                                    | strs -> String.concat "" strs

  