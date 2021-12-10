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
let iterList = ["Ryan"; "Thom"; "Jacob"]
let newIterList = List.iter(fun x -> printfn "Hello, %s" (x)) iterList
// Output:
// Hello, Ryan
// Hello, Thom
// Hello, Jacob

//Reduce function
let reducedList = 
    [1; 3; 5] //BONUS! I added a pipe
    |> List.reduce(fun x y -> x * y)
printfn "%d" reducedList //15


//Passing Function Values
//Pass by value is the default
let exampleFunc(x : int) =
    //x <- x + 5 can't assign x to a new value by default
    x

//Pass by reference with byref type
let exampleFuncByRef(x : byref<int>) = 
    x <- x + 5
    x

//Values still must be mutable
let mutable z = 1

//Use ampersand to pass address of value to function
let result = exampleFuncByRef &z

printfn "%d" result // 6


//SPECIALTIES
//Currying
//Normal function
let addTwoNumbersOriginal(x: int, y: int) = 
    x + y

//Explicitly curried version of above
//This is what happens behind the scenes with the compiler
let addTwoNumbers(x : int) =
    let subFunction(y : int) =
        x + y
    subFunction

//Currying in action
let x = 7
let y = 3

//x will now be 'baked in' to this partial function
let partialFunction = addTwoNumbers x

let result = partialFunction y
printfn "Curried Version: %d" result // 10
printfn "Regular Version: %d" (addTwoNumbers x y) // 10


//Piping
type Person(age : int) =
    let _age = age;
    member u.Age() = _age

let people = [Person(12); Person(30); Person(22)]

//this works, but is hard to follow at a glance
let avg = (List.reduce (+) (List.map (fun (x: Person) -> x.Age()) people)) / (List.length people)
printfn "Average Age: %d" avg //Average Age: 21


//this is clearer as to what happens step by step
let pipedavg = 
    people                          //Take the collection
    |> List.map (fun x -> x.Age())  //Get the ages
    |> List.reduce (+)              //Add them up
    |> ( fun x -> x / (List.length people))     //Divide by the number of people
printfn "Piped Average Age: %d" pipedavg //Piped Average Age: 21





