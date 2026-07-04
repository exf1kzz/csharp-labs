using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

internal sealed class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAccountRepository accounts,
        ISessionRepository sessions)
    {
        Accounts = accounts;
        Sessions = sessions;
    }

    public IAccountRepository Accounts { get; }

    public ISessionRepository Sessions { get; }
}