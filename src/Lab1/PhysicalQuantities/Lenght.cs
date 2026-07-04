namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public class Lenght
{
    public Lenght(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Lenght must be positive");
        }

        Value = value;
    }

    public double Value { get; set; }
}