module Leap

let leapYear (year: int): bool = 
    let isDivisibleBy4 = year % 4 = 0
    let isDivisibleBy100 = year % 100 = 0
    let isDivisibleBy400 = year % 400 = 0
    
    (isDivisibleBy4 && not isDivisibleBy100) || isDivisibleBy400