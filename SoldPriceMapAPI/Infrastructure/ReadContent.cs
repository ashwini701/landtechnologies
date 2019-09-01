using SoldPriceMapAPI.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoldPriceMapAPI.Infrastructure
{
    public interface IReadContent
    {
        List<HouseData> GetFileContent();
    }
    public class ReadContent : IReadContent
    {
        public List<HouseData> GetFileContent()
        {
            string line;
            string[] propertyCollection;
            StreamReader streamReader = new StreamReader(@"SoldPriceData.txt");

            List<HouseData> RawHouseData = new List<HouseData>();
            HouseData houseData = new HouseData();
            while ((line = streamReader.ReadLine()) != null)
            {
                propertyCollection = line.Split(' ');

                houseData = new HouseData();
                houseData.Price = double.Parse(propertyCollection[2]);
                houseData.XCoordinates = propertyCollection[0];
                houseData.YCoordinates = propertyCollection[1];
                RawHouseData.Add(houseData);
            }
            return RawHouseData;
        }
    }
}
