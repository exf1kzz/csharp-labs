using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly Dictionary<SessionId, ISession> _values = new();

    public void Add(ISession session)
    {
        _values.Add(session.Id, session);
    }

    public IEnumerable<ISession> Query(SessionQuery query)
    {
        return _values.Values
            .Where(s => query.Ids is [] || query.Ids.Contains(s.Id));
    }
}