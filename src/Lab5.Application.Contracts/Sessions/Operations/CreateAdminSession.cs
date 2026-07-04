using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(string SystemPassword);

    public readonly record struct Response(SessionDto Session);
}