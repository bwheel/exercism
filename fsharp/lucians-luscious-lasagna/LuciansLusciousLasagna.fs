module LuciansLusciousLasagna

let expectedMinutesInOven: int = 40

let remainingMinutesInOven (ellapsedTime: int): int  =
    expectedMinutesInOven - ellapsedTime

let preparationTimeInMinutes (numberLayers: int) : int = 
    numberLayers * 2

let elapsedTimeInMinutes (numberLayers: int) ( ellapsedTime: int): int =
    preparationTimeInMinutes numberLayers + ellapsedTime
