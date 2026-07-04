using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class ForceSegment : IRouteSegment
{
    private readonly Lenght _distance;
    private readonly double _force;

    public ForceSegment(Lenght lenght, double force)
    {
        _distance = lenght;
        _force = force;
    }

    public TravelResult Pass(Train train)
    {
        bool success = train.ApplyForce(_force);
        if (!success)
        {
            return new TravelResult(false, 0);
        }

        return train.Travel(_distance);
    }
}