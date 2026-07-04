namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

public sealed record AccountId
{
    public Guid Value { get; }

    public AccountId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty");
        }

        Value = value;
    }

    public static AccountId New() => new AccountId(Guid.NewGuid());
}