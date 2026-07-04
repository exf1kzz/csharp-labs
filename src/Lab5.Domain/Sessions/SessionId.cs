namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed record SessionId
{
    public Guid Value { get; }

    public SessionId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("SessionId cannot be empty");
        }

        Value = value;
    }

    public static SessionId New() => new(Guid.NewGuid());
}