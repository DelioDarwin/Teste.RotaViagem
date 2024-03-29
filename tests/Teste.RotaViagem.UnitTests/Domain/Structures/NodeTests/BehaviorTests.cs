using Teste.RotaViagem.Domain.Structures;
using Teste.RotaViagem.Domain.Travels;
using Teste.RotaViagem.UnitTests.Fixtures;

namespace Teste.RotaViagem.UnitTests.Structures.NodeTests;
public class BehaviorTests
{
    [Fact]
    public void Adding_Identical_Links_Should_Throw()
    {
        var expected = "BRB";
        // Given
        var sut = new MockNode(expected);
        var link = new Link(expected, new Location("CRG"), 10);
        // When
        sut.AddLink(link);

        var throwAction = () => sut.AddLink(link);
        // Then
        throwAction.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Links_Should_Not_Be_Null()
    {
        // Given
        var sut = new MockNode("CRG");
        // When
        sut.Links.Should().NotBeNull();
    }
}
