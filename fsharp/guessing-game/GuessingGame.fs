module GuessingGame

let reply (guess: int): string = 
    match guess with
    | 42 -> "Correct"
    | 41 | 43 -> "So close"
    | s when s < 41 -> "Too low"
    | s when s > 43 -> "Too high"
    | _ -> failwith "Invalid guess"