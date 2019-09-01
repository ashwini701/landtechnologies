using SoldPriceMapAPI.Contract;
using SoldPriceMapAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoldPriceMapAPI.Service
{
    public interface ISoldPriceMapService
    {
        PriceMapResponse GetSoldPriceMapData();
    }
    public class SoldPriceMapService : ISoldPriceMapService
    {
        private IReadContent _readContent;
        public SoldPriceMapService(IReadContent readContent)
        {
            _readContent = readContent;
        }
        public PriceMapResponse GetSoldPriceMapData()
        {

            List<HouseData> RawHouseData = _readContent.GetFileContent();
            double total = RawHouseData.Sum(x => x.Price);

            double max = RawHouseData.Max(x => x.Price);
            PriceMapResponse priceMapResponse = new PriceMapResponse();
            HouseInformation houseInformation;
            priceMapResponse.Houses = new List<HouseInformation>();
            foreach (var house in RawHouseData)
            {
                houseInformation = new HouseInformation()
                {
                    XCoordinates = house.XCoordinates,
                    YCoordinates = house.YCoordinates,
                    CostGroupRange = CalculateCostGroupRange(house.Price)
                };

                priceMapResponse.Houses.Add(houseInformation);
            }

            return priceMapResponse;
        }

        private string CalculateCostGroupRange(double price)
        {
           return  Convert.ToString(Math.Round((price / 10000000) * 100));
        }
    }
}
