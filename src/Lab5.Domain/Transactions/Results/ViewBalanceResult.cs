using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.Results;

public abstract record ViewBalanceResult
{
    private ViewBalanceResult() { }

    public sealed record Success(Money NewBalance) : ViewBalanceResult;

    public sealed record Failure(string Message) : ViewBalanceResult;
}