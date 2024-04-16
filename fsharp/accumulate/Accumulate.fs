module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = 
    let rec accRec (i: 'a list ) (acc: 'b list) : 'b list =
        match i with
        | [] -> acc
        | x :: xs -> accRec xs (func(x) :: acc)
    accRec input [] |> List.rev