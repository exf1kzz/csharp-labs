using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions;

public class Transaction
{
    public TransactionType Type { get; }

    public Money Amount { get; }

    public bool IsCompleted { get; private set; }

    public Transaction(TransactionType type, Money amount)
    {
        Type = type;
        Amount = amount;
        IsCompleted = false;
    }

    public void Complete() => IsCompleted = true;

    public void Fail() => IsCompleted = false;
}