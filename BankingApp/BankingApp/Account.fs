module Account

type BankAccount(acctNumber: int, username: string, balance: float, password: string) = 
    let _accountNumber = acctNumber
    let _username = username
    let mutable _balance = balance
    let _password = password


    member this.GetBalance() = 
        _balance

    member this.ValidateUser(providedUsername: string, providedPass: string) = 
        if not (providedUsername = _username) 
        then false
        elif not (providedPass = _password)
        then false
        else true


    member this.Withdraw(amount: float) =
        _balance <- _balance - amount
        
    member this.Deposit(amount: float) = 
        _balance <- _balance + amount

    member this.GetName() = 
        _username
