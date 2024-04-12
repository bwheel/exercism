module InterestIsInteresting

let interestRate (balance: decimal): single =
   match balance with
   | b when b < 0m -> 3.213f
   | b when b < 1000m -> 0.5f
   | b when b < 5000m -> 1.621f
   |_ -> 2.475f

let interest (balance: decimal): decimal =
      (balance |> interestRate |> decimal) * balance / 100m


let annualBalanceUpdate(balance: decimal): decimal =
   (balance |> interest) + balance

let amountToDonate(balance: decimal) (taxFreePercentage: float): int =
   if balance < 0m then
      0
   else
      int(balance * decimal(taxFreePercentage) * 2m / 100m)
