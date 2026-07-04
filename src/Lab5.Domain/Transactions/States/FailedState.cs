namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.States;

public class FailedState : ITransactionState
{
    public TransactionState State => TransactionState.Failed;

    public bool CanComplete => false;

    public bool CanFail => false;
}