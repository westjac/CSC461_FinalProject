module Administrator

open FSharp.Collections

type Administrator(initialaccts: List<Account.BankAccount>, baseapy: float) =
    let _accounts = initialaccts
    let _apy = baseapy

    static member Interest _apy = (fun x -> x * (1.0 + _apy))

    member this.ApplyInterest() =
        List.iter (fun (x: Account.BankAccount) -> x.Deposit(x.GetBalance() * _apy)) _accounts

    member this.ShowAccounts() =
        List.map (fun (x: Account.BankAccount) -> ($"Name: {x.GetName(),-10} Balance: ${x.GetBalance()}\n")) _accounts
        |> List.fold (fun acc x -> acc + x ) "\n"