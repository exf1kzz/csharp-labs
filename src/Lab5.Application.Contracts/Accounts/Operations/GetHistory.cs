using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class GetHistory
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(IReadOnlyList<TransactionDto> Transactions) : Response;

        public sealed record Failure(string Message) : Response;
    }
}