namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public class AdminSession : ISession
{
    public SessionId Id { get; }

    public AdminSession(SessionId id)
    {
        Id = id;
    }
}