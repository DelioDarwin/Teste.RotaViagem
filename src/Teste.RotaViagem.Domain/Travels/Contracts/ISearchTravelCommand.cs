
namespace Teste.RotaViagem.Domain.Travels.Contracts;
public interface ISearchTravelCommand
{
    public Location From { get; }
    public Location To { get; }
}