using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(Guid AccountId, string PinCode);

    public readonly record struct Response(SessionDto Session);
}