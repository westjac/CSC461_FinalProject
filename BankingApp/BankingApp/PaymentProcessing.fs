module PaymentProcessing

open Cash
open Check
open CreditCard
open Account

type PaymentType = 
    | Cash of CashDeposit
    | Card of CardInformation
    | Check of CheckInformation

let ProcessAPayment(methodOfPayment, account: Account.BankAccount) = 
    match methodOfPayment with
    | Cash cashInfo -> account.Deposit(cashInfo.amount)
    | Card cardInfo -> account.Deposit(cardInfo.amount)
    | Check checkInfo -> account.Deposit(checkInfo.amount)
