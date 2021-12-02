open System

[<EntryPoint>]
let main argv =
    let bank = new Bank.BankATM(1)
    let mutable choice = -1
    Console.WriteLine("Welcome to RTJ Bank! What would you like to do?") 
    while (choice <> 0) do
        Console.WriteLine()
        Console.WriteLine("Main Menu")
        Console.WriteLine(" 1 - Create An Account \n 2 - Log In \n 0 - Exit")
        Console.Write("choice:> ")
        choice <- int(Console.ReadLine())

        match choice with
        | 0 -> Console.WriteLine("\nMerry Christmas ya fithly animal!")
        | 1 -> bank.CreateAccount()
        | 2 -> bank.Login()
        | _ -> Console.WriteLine("Please enter a valid number")



    0 // return an integer exit code