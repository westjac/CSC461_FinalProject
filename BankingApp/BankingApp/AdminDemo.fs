module AdminDemo

open Administrator
open System

let run =
    let demoAccts = [new Account.BankAccount(0, "Dave", 1403.22, "password1");
                     new Account.BankAccount(1, "Steve", 830.57, "password2");
                     new Account.BankAccount(2, "Jill", 4333.00, "password3");
                     new Account.BankAccount(3, "Jeff", 1403.22, "password4");
                     new Account.BankAccount(4, "Carl", 2475.74, "password5");
                     new Account.BankAccount(5, "Alice", 624.26, "password6");
                     new Account.BankAccount(6, "Bob", 2456.24, "password7");
                     new Account.BankAccount(7, "Dave Two", 1987.45, "password8")]

    let bankAdmin = new Administrator(demoAccts, 0.009)

    
    let mutable choice = -1
    Console.WriteLine("You now have the power.") 
    while (choice <> 0) do
        Console.WriteLine()
        Console.WriteLine("Main Menu")
        Console.WriteLine(" 1 - View account balances \n 2 - Apply monthly dividends \n 0 - Exit to top menu")
        Console.Write("choice:> ")
        choice <- int(Console.ReadLine())

        match choice with
        | 0 -> Console.WriteLine("\nGood work today!")
        | 1 -> Console.Write (bankAdmin.ShowAccounts())
        | 2 -> bankAdmin.ApplyInterest()
        | _ -> Console.WriteLine("Please enter a valid number")