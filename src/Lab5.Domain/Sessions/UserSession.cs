using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public class UserSession : ISession
{
    public SessionId Id { get; }

    public AccountId AccountId { get; }

    public UserSession(SessionId id, AccountId accountId)
    {
        Id = id;
        AccountId = accountId;
    }
}