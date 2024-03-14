using System.Text;
using Awarean.Sdk.ValueObjects;
using Teste.RotaViagem.Domain.Travels;
using Teste.RotaViagem.Domain.Travels.Contracts;

namespace Teste.RotaViagem.Application.CheapestRouteCalculation.Contracts
{
    public class CheapestTravelResponse : ICheapestTravelResponse
    {
        public Location StartingPoint { get; private set; }
        public Location Destination { get; private set; }
        public Money TotalAmount { get; private set; }
        public LinkedList<(string Location, decimal Amount)> BestTravelRoute { get; private set; }

        public CheapestTravelResponse(Location startingPoint, Location destination, Money totalAmount, LinkedList<(string Location, decimal Amount)> bestTravelRoute)
        {
            StartingPoint = startingPoint ?? throw new ArgumentNullException(nameof(startingPoint));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            TotalAmount = totalAmount ?? throw new ArgumentNullException(nameof(totalAmount));
            BestTravelRoute = bestTravelRoute ?? throw new ArgumentNullException(nameof(bestTravelRoute));
        }

        public string DescribeCheapestTravel()
        {
            var stringBuilder = new StringBuilder();

            var node = BestTravelRoute.First;

            while (node is not null)
            {
                stringBuilder.Append($"{node.Value.Location} -> ");
                node = node.Next;
            }
            stringBuilder.Append($"Valor total de: {TotalAmount:C2}.");

            return stringBuilder.ToString();
        }
    }
}