namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.States;

public interface ITransactionState
{
    TransactionState State { get; }

    bool CanComplete { get; }

    bool CanFail { get; }
}