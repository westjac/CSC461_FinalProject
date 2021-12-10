module SectionTwo

//Syntax & OOP

// 1) Example of one type of assignment expression

let myVar = 7
// myVar <- 10 This doesn't work becasue assinments are immutable by default

let mutable myMutableVar = 7
myMutableVar <- 10 //This is how you do assignment after declaration

//Print with the print function
//Utilizes the text writer format
printfn "Current Count: %d" 25

//Functions
let myFunction(word: string) =
    printfn "%s" word


myFunction("Hello")
//Function returing something
let squared(x: int) = 
    //The last line is what is returned
    x * x

let fourSquared = squared 4
printfn "%d" fourSquared

// 2) How does the language support extension?

//Class inheritance
type baseClass() =
    let x = 0

type derivedClass() =
    inherit baseClass()
    let y = 0


//Virtual Methods & Overrides
type baseClass1() =
    let mutable z = 0
    abstract member func1 : int -> int
    default u.func1(a : int) = z <- z + a; z //Add a to z, return z

let baseFunc = baseClass1()
printfn "Base func1: %d" (baseFunc.func1(2)) //Base func1: 2

type derivedClass1() = 
    inherit baseClass1()
    override u.func1(a : int) = a + 1 //Add 1 to a and return the value

let derivedFunc = derivedClass1()
printfn "Derived func1: %d" (baseFunc.func1(2)) //Derived func1: 3


// Object Expression
open System

let objectBase = new Object()

//This overrides ToString() only for this object instance
let objectOverride = { new Object() with
    override this.ToString() = "This overrides object.ToString()" }

printfn "%s" (objectBase.ToString()) //Default ToString()

printfn "%s" (objectOverride.ToString()) //Overriden ToString()

