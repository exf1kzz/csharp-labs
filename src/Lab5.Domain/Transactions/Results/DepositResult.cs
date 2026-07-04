using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.Results;

public abstract record DepositResult
{
    private DepositResult() { }

    public sealed record Success(Money NewBalance) : DepositResult;

    public sealed record Failure(string Message) : DepositResult;
}