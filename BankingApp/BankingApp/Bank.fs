module Bank

open System
open UserAuthentication
open PaymentProcessing
open CreditCard
open Cash
open Check

type BankATM(startingAccountNumber: int) = 
    let mutable _currentAccountNumber = startingAccountNumber
    let mutable _accounts = []
    let accountManager = new UserManager()

    member this.CreateAccount() = 
        let newAccount = accountManager.OpenNewAccount(_currentAccountNumber)
        _currentAccountNumber <- _currentAccountNumber + 1
        let tempList = [newAccount]
        _accounts <- _accounts @ tempList

        () // returns a unit (void)

    member this.Login() = 
        Console.Write("\nEnter your account number:> ")
        let accountNumber = int(Console.ReadLine())

        if int(accountNumber) <= 0 then Console.WriteLine("Please enter a valid account number")
        elif int(accountNumber) > _accounts.Length then Console.WriteLine("Please enter a valid account number")
        else
            let (account: Account.BankAccount) = this.GetAccount(accountNumber - 1)
            let validated = accountManager.Validate(account)

            if validated then this.DisplaySubMenu(account)
            else Console.WriteLine("Wrong username and/or password")
            
        ()


    member this.GetAccount(accountIndexToGet: int) = 
        _accounts.[accountIndexToGet]

    member this.DisplaySubMenu(account: Account.BankAccount) =
        let mutable choice = -1

        Console.WriteLine("Welcome, {0}!", account.GetName())
        
        while(choice <> 0) do
            Console.WriteLine(" 1 - Withdraw \n 2 - Deposit \n 3 - View Balance \n 0 - Exit")
            Console.Write("choice:> ")
            choice <- int(Console.ReadLine())
            
            match choice with
            | 0 -> Console.WriteLine("Goodbye!")
            | 1 -> this.Withdraw(account)
            | 2 -> this.Deposit(account)
            | 3 -> this.ViewDetails(account)
            | _ -> Console.WriteLine("Bad Input")
        ()

    member this.Withdraw(account: Account.BankAccount) = 
        Console.Write("\nPlease enter the Amount:> ")
        let amount = float(Console.ReadLine())
        account.Withdraw(amount)

        ()

    member this.Deposit(account: Account.BankAccount) = 
        Console.Write("\nPlease enter the Amount:> ")
        let amount = float(Console.ReadLine())
        Console.WriteLine("Enter Method of Payment:")
        Console.WriteLine(" 1 - Cash \n 2 - Check \n 3 - Card")
        Console.Write("choice:> ")
        let paymentType = int(Console.ReadLine())

        match paymentType with
        | 1 -> this.DepositCash(amount, account)
        | 2 -> this.DepositCheck(amount, account)
        | 3 -> this.DepositCard(amount, account)
        | 4-> Console.WriteLine("Invalid choice")

        ()

    member this.ViewDetails(account: Account.BankAccount) = 
        let name = account.GetName()
        let pass = account.GetPass()
        let balance = account.GetBalance()

        Console.WriteLine("\nUsername: {0}", name)
        Console.WriteLine("Password: {0}", pass)
        Console.WriteLine("Balance: ${0}", balance)
        Console.WriteLine()
        ()

    member this.DepositCash(depositAmount: float, account: Account.BankAccount) = 
        let info = {amount = depositAmount;}
        let cash = PaymentType.Cash(info)
        ProcessAPayment(cash, account)
        ()

    member this.DepositCheck(depositAmount: float, account: Account.BankAccount) = 
        Console.WriteLine("\nEnter Your Check Information:")
        Console.Write(" Check Number:> ")
        let checkNum = Console.ReadLine()

        Console.Write(" Routing Number:> ")
        let routing = int(Console.ReadLine())

        Console.Write(" Account Number:> ")
        let accountNum = int(Console.ReadLine())
    
        let info = {amount = depositAmount; CheckNumber = checkNum; RoutingNumber = routing; AccountNumber = accountNum;}
        let check = PaymentType.Check(info)
        ProcessAPayment(check, account)
        ()

    member this.DepositCard(depositAmount: float, account: Account.BankAccount) = 
        Console.WriteLine("\nEnter Your Card Information:")
        Console.Write(" Card Number:> ")
        let cardNum = Console.ReadLine()

        Console.Write(" Month Expiration:> ")
        let monthExp = int(Console.ReadLine())

        Console.Write(" Year Expiration:> ")
        let yearExp = int(Console.ReadLine())

        Console.Write(" CVV Number:> ")
        let CVVNumber = int(Console.ReadLine())

        let info = {amount = depositAmount; CardNumber = cardNum; Month=monthExp; Year=yearExp; CVV=CVVNumber;}
        let card = PaymentType.Card(info)
        ProcessAPayment(card, account)
        ()


        
