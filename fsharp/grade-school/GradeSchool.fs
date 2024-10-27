module GradeSchool

type School = Map<int, string list>

let empty: School = 
    let x: School = Map.empty<int, string list>
    x

let add (student: string) (grade: int) (school: School): School = 
    let students = (school.[grade] @ [student])
    school.Add (grade, students)
    
let roster (school: School): string list = 
    school.Keys |> Seq.cast |> Seq.map (fun k -> school.[k]) |> Seq.concat |> List.ofSeq

let grade (number: int) (school: School): string list = 
    school.[number]
