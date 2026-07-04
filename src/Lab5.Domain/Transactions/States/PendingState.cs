namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.States;

public sealed class PendingState : ITransactionState
{
    public TransactionState State => TransactionState.Pending;

    public bool CanComplete => true;

    public bool CanFail => true;
}