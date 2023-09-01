module Raindrops

/// Euclidean remainder, the proper modulo operation
let inline (%!) a b = (a % b + b) % b

let convert (number: int): string = 
    let isDivBy3 (num): bool = num %! 3 = 0
    let isDivBy5 (num): bool = num %! 5 = 0
    let isDivBy7 (num): bool = num %! 7 = 0
    
    let keys = [3; 5; 7]
    
    

    ""