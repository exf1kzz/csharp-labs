namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public class MaxForce
{
    public MaxForce(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Force must be positive");
        }

        Value = value;
    }

    public double Value { get; set; }
}