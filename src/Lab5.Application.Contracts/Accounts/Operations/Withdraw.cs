using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class Withdraw
{
    public readonly record struct Request(Guid SessionKey, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Account) : Response;

        public sealed record Failure(string Message) : Response;
    }
}