module CarsAssemble

let successRate (speed: int) : float =
    match speed with
    | 0 -> 0.0
    | s when s <= 4 -> 1.0
    | s when s <= 8 -> 0.9
    | s when s = 9 -> 0.8
    | s when s = 10 -> 0.77
    | _ -> 0.0

let productionRatePerHour (speed: int) : float =
    successRate (speed) * float (speed) * 221.0

let workingItemsPerMinute (speed: int) : int =
    int (productionRatePerHour (speed) / 60.0)
