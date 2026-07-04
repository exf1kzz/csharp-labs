namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

public sealed record Money
{
    public Money(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }

        Value = value;
    }

    public decimal Value { get; }
}