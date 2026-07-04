namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.States;

public sealed class CompletedState : ITransactionState
{
    public TransactionState State => TransactionState.Completed;

    public bool CanComplete => false;

    public bool CanFail => false;
}