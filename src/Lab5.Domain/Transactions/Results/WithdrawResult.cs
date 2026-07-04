using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.Results;

public abstract record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success(Money NewBalance) : WithdrawResult;

    public sealed record Failure(string Message) : WithdrawResult;
}