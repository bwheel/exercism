module QueenAttack

let create (x: int32, y: int32) = 
    let inBounds(d) =
        d > -1 && d < 8
    inBounds x && inBounds y

let canAttack (queen1: int * int) (queen2: int * int) = 
    let canDiagonalAttack (x1, y1) (x2, y2) =
        let xdiff = x1 - x2
        let ydiff = y1 - y2
        ydiff <> 0 && xdiff <> 0 // Check for divide-by-zero
        && abs(xdiff/ydiff) = 1  // if the slope is 1, it's a pure diagonal

    let canRowAttack (x1, _) (x2, _) = x1 = x2
    
    let canColumnAttack (_, y1) (_, y2) = y1 = y2

    canDiagonalAttack queen1 queen2 
    || canRowAttack queen1 queen2 
    || canColumnAttack queen1 queen2