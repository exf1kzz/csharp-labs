using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;

public class Train
{
    private readonly MaxForce _maxForce;
    private readonly Speed _speed;
    private readonly Weight _weight;
    private readonly Time _precisionTime;
    private double _acceleration;

    public Train(MaxForce maxForce, Weight weight, Time presisionTime)
    {
        _maxForce = maxForce;
        _weight = weight;
        _precisionTime = presisionTime;
        _speed = new Speed(0);
    }

    public bool ApplyForce(double force)
    {
        if (Math.Abs(force) > _maxForce.Value)
        {
            return false;
        }

        _acceleration = force / _weight.Value;
        return true;
    }

    public bool IsSpeedAbove(double limit)
    {
        return _speed.Value > limit;
    }

    public TravelResult Travel(Lenght distance)
    {
        double remaining = distance.Value;
        double totalTime = 0;

        while (remaining > 0)
        {
            if (_speed.Value <= 0 && _acceleration <= 0)
            {
                return new TravelResult(false, totalTime);
            }

            double newSpeed = _speed.Value + (_acceleration * _precisionTime.Value);
            if (newSpeed < 0)
            {
                return new TravelResult(false, totalTime);
            }

            double traveled = newSpeed * _precisionTime.Value;
            remaining -= traveled;
            _speed.Update(newSpeed);
            totalTime += _precisionTime.Value;
        }

        return new TravelResult(true, totalTime);
    }
}