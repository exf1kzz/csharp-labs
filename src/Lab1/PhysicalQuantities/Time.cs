namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

public class Time
{
    public Time(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Time must be positive");
        }

        Value = value;
    }

    public double Value { get; set; }
}