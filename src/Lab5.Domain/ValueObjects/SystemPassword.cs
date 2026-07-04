namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

public sealed record SystemPassword
{
    public SystemPassword(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("System password cannot be empty");
        }

        Value = value;
    }

    public string Value { get; }
}