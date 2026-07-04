using Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public interface IRouteSegment
{
    TravelResult Pass(Train train);
}