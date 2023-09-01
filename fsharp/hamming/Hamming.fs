module Hamming
open System

let distance (strand1: string) (strand2: string): int option = 
    isEmpty(s: string) =
        s != null && s.Trim().Length <= 0

    
    if isEmpty(strand1) && isEmpty(strand2 then Some 0
    elif isEmpty(strand1) <= 0 || isEmpty(strand2) then None
    else Some(0)
