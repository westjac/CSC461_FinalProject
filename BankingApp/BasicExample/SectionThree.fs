module SectionThree

//Binding, Type System, and Data Type Ranges


// 1) Static Typing
let y = "Three"
//y <- 3 Will not work because y is immutable

let mutable z = "Six"
//z <- 6 Will not work becasue of type missmatch



// 2) Static Scoping
let x = 0

let B() =
    //Prints x from program, not where B is called
    printfn "%s" (x.ToString())

let A() = 
    let x = 1
    B()

A() //Prints 0


// 3) Reading the language

//Math my default is evaluated with in-fix notation
let inFix = 2 + 5
printfn "In-Fix: %s" (inFix.ToString()) //Prints 7


//You can also evaluate with pre-fix if you so desire
let preFix = (+) 2 5
printfn "Pre-Fix: %s" (preFix.ToString()) //Prints 7
