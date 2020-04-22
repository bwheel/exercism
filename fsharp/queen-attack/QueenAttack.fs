module QueenAttack

let create (position: int * int) = 
    let inBounds(d:int) =
        d > -1 && d < 8
    position |> fst |> inBounds 
    && position |> snd |> inBounds

let canAttack (queen1: int * int) (queen2: int * int) = 
    let canDiagonalAttack(queen1: int * int, queen2:int * int) =
        let x1, y1 = queen1
        let x2, y2 = queen2
        let xdiff = x1 - x2
        let ydiff = y1 - y2
        ydiff <> 0 && xdiff <> 0 // Check for divide-by-zero
        && abs(xdiff/ydiff) = 1  // if the slope is 1, it's a pure diagonal

    let canRowAttack(queen1: int * int, queen2: int * int) = 
        let x1, _ = queen1
        let x2, _ = queen2
        x1 = x2
    
    let canColumnAttack(queen1: int * int, queen2: int * int) = 
        let _, y1 = queen1
        let _, y2 = queen2
        y1 = y2

    canDiagonalAttack(queen1, queen2) 
    || canRowAttack(queen1, queen2) 
    || canColumnAttack(queen1, queen2)