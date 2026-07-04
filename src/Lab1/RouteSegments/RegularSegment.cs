using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class RegularSegment : IRouteSegment
{
    private readonly Lenght _distance;

    public RegularSegment(Lenght lenght)
    {
        _distance = lenght;
    }

    public TravelResult Pass(Train train)
    {
        return train.Travel(_distance);
    }
}