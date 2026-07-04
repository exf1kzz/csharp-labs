using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteAndResult;

public class Route
{
    private readonly IReadOnlyList<IRouteSegment> _segments;
    private readonly double _maxAllowedSpeed;

    public Route(IReadOnlyList<IRouteSegment> segments, double maxAllowedSpeed)
    {
        _segments = segments.ToList();
        _maxAllowedSpeed = maxAllowedSpeed;
    }

    public RouteResult Run(Train train)
    {
        double totalTime = 0;

        foreach (IRouteSegment segment in _segments)
        {
            TravelResult result = segment.Pass(train);
            if (!result.Success)
            {
                return new RouteResult(false, totalTime);
            }

            totalTime += result.Time;
        }

        if (train.IsSpeedAbove(_maxAllowedSpeed))
        {
            return new RouteResult(false, totalTime);
        }

        return new RouteResult(true, totalTime);
    }
}