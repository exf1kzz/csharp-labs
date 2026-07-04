namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

public sealed record PinCode
{
    public PinCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("PinCode cannot be empty");
        }

        if (value.Length != 4 || !value.All(char.IsDigit))
        {
            throw new ArgumentException("PinCode must contain 4 digits");
        }

        Value = value;
    }

    public string Value { get; }
}