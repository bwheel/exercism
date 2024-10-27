module Clock

type clock = {
    Hours: int
    Minutes: int
}


let minuteRemainder (minutes: int): int =
    match minutes with
    | m when m >= 60 -> m % 60
    | _ -> minutes

let hoursInMinutes (minutes: int): int =
    if minutes >= 60 then
        minutes / 60
    else
        0

let hoursRemainder (hours: int) (minutes: int): int =
    let hoursAndMinutes = hours + hoursInMinutes minutes
    match hoursAndMinutes with
    | h when h >= 24 -> h % 24
    | _ -> hoursAndMinutes


let create hours minutes = 
    let totalMinutes = minuteRemainder minutes
    let totalHours = hoursRemainder hours minutes
    { Hours = totalHours; Minutes = totalMinutes}

let add minutes clock = failwith "You need to implement this function."

let subtract minutes clock = failwith "You need to implement this function."

let display (clock: clock): string = 
    sprintf "%02d:%02d" clock.Hours clock.Minutes