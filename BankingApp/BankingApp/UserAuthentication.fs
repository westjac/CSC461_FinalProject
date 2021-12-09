module UserAuthentication
open System
open Account
type UserManager() = 

    member this.OpenNewAccount(accountNumber: int) = 
        Console.WriteLine("\nAccount Creation Menu")
        Console.Write("Enter a username:> ")
        let username = Console.ReadLine()

        Console.Write("Enter a password:> ")
        let password = Console.ReadLine()

        Console.WriteLine("\n \nYour account details are as follows: ")
        Console.WriteLine("account number : {0}", accountNumber)
        Console.WriteLine("username       : {0}", username)
        Console.WriteLine("password       : {0}", password)

        let startingBalance = 0.0

        let newAccount = new Account.BankAccount(accountNumber, username, startingBalance, password)

        newAccount

    member this.Validate(account: Account.BankAccount) =
        Console.Write("Enter your username:> ")
        let username = Console.ReadLine()
        Console.Write("Enter your password:> ")
        let password = Console.ReadLine()
        Console.WriteLine()

        let validated = account.ValidateUser(username, password)
        
        validated
        

