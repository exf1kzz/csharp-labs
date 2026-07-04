using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public sealed class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    private readonly SystemPassword _systemPassword;

    public SessionService(IPersistenceContext context, SystemPassword systemPassword)
    {
        _context = context;
        _systemPassword = systemPassword;
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        var accountId = new AccountId(request.AccountId);
        var sessionId = SessionId.New();

        var userSession = new UserSession(sessionId, accountId);
        _context.Sessions.Add(userSession);
        return new CreateUserSession.Response(userSession.MapToDto());
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        if (request.SystemPassword != _systemPassword.Value)
        {
            throw new ArgumentException("Invalid system password");
        }

        var sessionId = SessionId.New();
        var adminSession = new AdminSession(sessionId);

        _context.Sessions.Add(adminSession);

        return new CreateAdminSession.Response(adminSession.MapToDto());
    }
}