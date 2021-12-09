module SectionFour

//Control flow, function, and specialties


// 1) Selection & Repetition Structures

//If, Elif, and Else
let x = -5

if x > 0 then
    printfn "%s" ("Greater than 0")
elif x < 0 then
    printfn "%s" ("Less than 0")
else
    printfn "%s" ("Equal to 0")

// For ... In loop with list
let list1 = [1; 3; 5; 7]
for number in list1 do
    printfn "%d" number //1, 3, 5, 7

//For ... In loop with range
for x in 1..7 do
    printfn "%d" x //1, 2, 3, 4, 5, 6, 7

//For ... In loop with range & skip
for x in 1..2..7 do
    printfn "%d" x //1, 3, 5, 7

//For ... To loop with range
for i = 0 to 4 do
    printfn "%d" i //0, 1, 2, 3, 4

//While ... Do loop
let mutable x = 1
while x <> 5 do // <> = not equal
    printfn "%d" x
    x <- x + 1 //1, 2, 3, 4

//Map function
let mapList = [0; 2; 4]
let newMapList = List.map( fun x -> x + 1 ) mapList
printfn "%A" newMapList //1, 3, 5

//Map 2: operate on two lists in one map function
let mapList2 = [10; 20; 30]
let newMapList2 = List.map2(fun x y -> x + y) mapList mapList2
printfn "%A" newMapList2 //10, 22, 34

//Filter function
let filterList = [1; 2; 3; 4; 5; 6]
let filteredList = List.filter(fun x -> x%2 <> 0) filterList // <> = not equal
printfn "%A" filteredList //1, 3, 5

//Iter function
type Person(x: String) = 
    let name = x
    member getName() =
        name


let iterList = ["Ryan"; "Thom"; "Jacob"]
let newIterList = List.iter(fun x -> printfn "Hello, %s" (x)) iterList




