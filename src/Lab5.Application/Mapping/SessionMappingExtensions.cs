using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class SessionMappingExtensions
{
    public static SessionDto MapToDto(this ISession session)
        => new SessionDto(session.Id.Value, session is UserSession ? "User" : "Admin");
}