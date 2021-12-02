module Bank

open System

type BankATM(startingAccountNumber: int) = 
    let mutable _currentAccountNumber = startingAccountNumber
    let mutable _accounts = []

    member this.CreateAccount() = 
        Console.WriteLine("\nAccount Creation Menu")
        Console.Write("Enter a username:> ")
        let username = Console.ReadLine()

        Console.Write("Enter a password:> ")
        let password = Console.ReadLine()

        Console.WriteLine("\n \nYour account details are as follows: ")
        Console.WriteLine("account number : {0}", _currentAccountNumber)
        Console.WriteLine("username       : {0}", username)
        Console.WriteLine("password       : {0}", password)

        let newAccount = new Account.BankAccount(_currentAccountNumber, username, 0.0, password)
        _currentAccountNumber <- _currentAccountNumber + 1
        let tempList = [newAccount]
        _accounts <- _accounts @ tempList

        () // returns a unit (void)

    member this.Login() = 
        Console.Write("\nEnter your account number:> ")
        let accountNumber = Console.ReadLine()
        Console.Write("Enter your username:> ")
        let username = Console.ReadLine()
        Console.Write("Enter your password:> ")
        let password = Console.ReadLine()
        Console.WriteLine()

        if int(accountNumber) <= 0 then Console.WriteLine("Please enter a valid account number")
        elif int(accountNumber) > _accounts.Length then Console.WriteLine("Please enter a valid account number")
        else 
            let (account: Account.BankAccount) = this.GetAccount(int(accountNumber) - 1)
            this.Validate(account, username, password)
            
        ()


    member this.GetAccount(accountNumber: int) = 
        _accounts.[accountNumber]

    member this.Validate(account: Account.BankAccount, username: string, password: string) = 
        let validated = account.ValidateUser(username, password)

        if validated then Console.WriteLine("Welcome {0}!", account.GetName()) 
        else Console.WriteLine("Wrong username and/or password")
