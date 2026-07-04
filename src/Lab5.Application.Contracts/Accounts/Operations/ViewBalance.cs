namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class ViewBalance
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal Balance) : Response;

        public sealed record Failure(string Message) : Response;
    }
}