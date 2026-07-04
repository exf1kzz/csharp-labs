using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class StationSegment : IRouteSegment
{
    private readonly double _maxArrivalSpeed;
    private readonly Time _stopTime;

    public StationSegment(double maxArrivalSpeed, Time stopTime)
    {
        _maxArrivalSpeed = maxArrivalSpeed;
        _stopTime = stopTime;
    }

    public TravelResult Pass(Train train)
    {
        if (train.IsSpeedAbove(_maxArrivalSpeed))
        {
            return new TravelResult(false, 0);
        }

        return new TravelResult(true, _stopTime.Value);
    }
}