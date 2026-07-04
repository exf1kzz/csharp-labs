namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public class Speed
{
    public Speed(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Speed must be positive");
        }

        Value = value;
    }

    public void Update(double value)
    {
        Value = value;
    }

    public double Value { get; set; }
}