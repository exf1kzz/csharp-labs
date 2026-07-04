namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions;

public class TransactionType
{
    public string Name { get; }

    public TransactionType(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}