namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public class Weight
{
    public Weight(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Weight must be positive");
        }

        Value = value;
    }

    public double Value { get; set; }
}