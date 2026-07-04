using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    void Add(ISession session);

    IEnumerable<ISession> Query(SessionQuery query);
}