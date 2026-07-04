using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteAndResult;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.TrainAndResult;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TrainTests
{
    [Fact]
    public void ApplyForce_ShouldReturnTrue_WhenForceWithinLimit()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segments = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(500), 50),

            new RegularSegment(new Lenght(1000)),
        };

        var route = new Route(segments, 1000);

        RouteResult result = route.Run(train);
        Assert.True(result.Success);
        Assert.True(result.TotalTime > 0);
    }

    [Fact]
    public void ApplyForce_ShouldReturnFalse_WhenForceNotWithinLimit()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segments = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(500), 1001),

            new RegularSegment(new Lenght(1000)),
        };

        var route = new Route(segments, 10000);

        RouteResult result = route.Run(train);
        Assert.False(result.Success);
    }

    [Fact]
    public void ApplyForce_ShouldReturnTrue_WhenForceWithinSegmentAndStation()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segments = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(500), 10),

            new RegularSegment(new Lenght(1000)),

            new StationSegment(100, new Time(10)),

            new RegularSegment(new Lenght(1000)),
        };

        var route = new Route(segments, 10000);
        RouteResult result = route.Run(train);
        Assert.True(result.Success);
        Assert.True(result.TotalTime > 0);
    }

    [Fact]
    public void ApplyForce_ShouldReturnFalse_WhenForceNotWithinStation()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segments = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(500), 100),

            new StationSegment(1, new Time(10)),

            new RegularSegment(new Lenght(1000)),
        };

        var route = new Route(segments, 10000);
        RouteResult result = route.Run(train);
        Assert.False(result.Success);
    }

    [Fact]
    public void ApplyForce_ShouldReturnFalse_WhenFroceNotinSegmentAndinStation()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segments = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(1000), 600),
            new RegularSegment(new Lenght(1000)),
            new StationSegment(150, new Time(5)),
            new RegularSegment(new Lenght(1000)),
        };

        var route = new Route(segments, 10);

        RouteResult result = route.Run(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void ApplyForce_ShouldReturnTrue_WhenMixedForceAndSegments()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segmants = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(1000), 500),

            new RegularSegment(new Lenght(1000)),

            new ForceSegment(new Lenght(500), -400),

            new StationSegment(150, new Time(5)),

            new RegularSegment(new Lenght(500)),

            new ForceSegment(new Lenght(1000), 700),

            new RegularSegment(new Lenght(1000)),

            new ForceSegment(new Lenght(500), -700),
        };

        var route = new Route(segmants, 1000);

        RouteResult result = route.Run(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RegularSegment_ShouldReturnFalse()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        var segments = new IRouteSegment[]
        {
            new RegularSegment(new Lenght(1000)),
        };

        var route = new Route(segments, 10000);

        RouteResult result = route.Run(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void Route_WhithOppositeForces_ShouldReturnFalse()
    {
        var train = new Train(
            new MaxForce(1000),
            new Weight(500),
            new Time(0.01));

        double x = 500;
        double y = 300;

        var segments = new IRouteSegment[]
        {
            new ForceSegment(new Lenght(x), y),
            new ForceSegment(new Lenght(x), -2 * y),
        };

        var route = new Route(segments, 10000);

        RouteResult result = route.Run(train);

        Assert.False(result.Success);
    }
}