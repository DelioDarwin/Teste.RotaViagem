using Microsoft.Extensions.Logging;
using Teste.RotaViagem.Application.CheapestRouteCalculation;
using Teste.RotaViagem.Domain.Structures;
using static Teste.RotaViagem.UnitTests.Fixtures.FixtureHelper;

namespace Teste.RotaViagem.UnitTests.Application.SearchEngine.TravelGraphBuildEngineTests;

public class MakeDirectedGraphTests
{
    private readonly INodeBuilder _nodeBuilder;
    private readonly IGraphBuilder _graphBuilder;
    public MakeDirectedGraphTests() => (_nodeBuilder, _graphBuilder) = (new NodeBuilder(), new GraphBuilder());

    [Fact]
    public void Valid_Travel_List_Should_Build_Graph()
    {
        // Given
        var travelList = GetTravelList();
        var logger = Substitute.For<ILogger<TravelGraphBuildEngine>>();
        var sut = new TravelGraphBuildEngine(_graphBuilder, _nodeBuilder, logger);

        // When
        var result = sut.BuildGraph(travelList);
        var graph = result.Value;

        var expectedCount = GetPlaces().Count();
        // Then
        result.IsSuccess.Should().BeTrue();
        graph.Nodes.Should().HaveCount(expectedCount);
    }
}
