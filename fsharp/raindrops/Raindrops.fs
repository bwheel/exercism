module Raindrops


let convert (number: int): string = 
    let factors = 
        [(3, "Pling");(5,"Plang");(7,"Plong")]
        |> List.map (fun (f, txt) -> if number % f = 0 then txt else "" )
        |> List.reduce(fun acc e -> acc + e )

    if factors = "" then
        number |> string
    else
        factors