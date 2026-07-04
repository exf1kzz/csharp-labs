using Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

public class Account
{
    public AccountId Id { get; }

    public PinCode Pin { get; }

    public Money Balance { get; private set; }

    private readonly List<Transaction> _transactions = new();

    public Account(AccountId id, PinCode pin)
    {
        Id = id;
        Pin = pin;
        Balance = new Money(0);
    }

    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public DepositResult Deposit(Money amount)
    {
        if (amount.Value <= 0)
        {
            return new DepositResult.Failure("Deposit must be positive");
        }

        Balance = new Money(Balance.Value + amount.Value);

        var transaction = new Transaction(new DepositType(), amount);
        transaction.Complete();
        _transactions.Add(transaction);

        return new DepositResult.Success(Balance);
    }

    public WithdrawResult Withdraw(Money amount)
    {
        if (amount.Value <= 0)
        {
            return new WithdrawResult.Failure("Withdrawal must be positive");
        }

        if (Balance.Value < amount.Value)
        {
            return new WithdrawResult.Failure("Insufficient funds");
        }

        Balance = new Money(Balance.Value - amount.Value);

        var transaction = new Transaction(new WithdrawType(), amount);
        transaction.Complete();
        _transactions.Add(transaction);

        return new WithdrawResult.Success(Balance);
    }

    public ViewBalanceResult ViewBalance()
    {
        return new ViewBalanceResult.Success(Balance);
    }
}