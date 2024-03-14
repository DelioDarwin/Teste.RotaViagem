
using System.Diagnostics;
using Teste.RotaViagem.Application.CheapestRouteCalculation;
using Teste.RotaViagem.UnitTests.Fixtures;
using static Teste.RotaViagem.UnitTests.Fixtures.FixtureHelper;

namespace Teste.RotaViagem.UnitTests.Application.CheapestRouteCalculation.CheapestTravelFinderTests;

public class FindShortestPathTests
{
    [Fact]
    public void Searching_Shortest_Path_Should_Pass()
    {
        // Given
        var travelList = GetTravelList();
        var startingPoint = "GRU";
        var destination = "CDG";

        var engine = FixtureHelper.GetTravelGraphBuildEngine();
        var sut = new CheapestTravelFinder(engine);
        // When
        var result = sut.FindShortestPath(startingPoint, destination, travelList);

        // Then
        result.IsSuccess.Should().BeTrue();
        result.Value.Last.Value.CostFromSource.Should().Be(40);
    }

    [Fact]
    public void Inexistent_Starting_Point_Should_Fail()
    {
        var travelList = GetTravelList();
        var inexistentStartingPoint = "INEXISTENT_STARTING_POINT";
        var travel = travelList[new Random().Next(0, travelList.Count)];
        var engine = GetTravelGraphBuildEngine();

        var sut = new CheapestTravelFinder(engine);

        var result = sut.FindShortestPath(inexistentStartingPoint, travel.Connection.Destination, travelList);

        result.IsFailed.Should().BeTrue();
        result.Error.Message.Should().Contain("Starting point");
    }

    [Fact]
    public void Inexistent_Destination_Should_Fail()
    {
        var travelList = GetTravelList();
        var travel = travelList[new Random().Next(0, travelList.Count)];
        var inexistentDestination = "INEXISTENT_DESTINATION";
        var engine = GetTravelGraphBuildEngine();

        var sut = new CheapestTravelFinder(engine);

        var result = sut.FindShortestPath(travel.Connection.StartingPoint, inexistentDestination, travelList);

        result.IsFailed.Should().BeTrue();
        result.Error.Message.Should().Contain("Destination") ;
    }

}
