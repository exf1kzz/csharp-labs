using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;

public interface ISessionService
{
    CreateUserSession.Response CreateUserSession(CreateUserSession.Request request);

    CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request);
}