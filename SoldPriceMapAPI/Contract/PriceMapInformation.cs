using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoldPriceMapAPI.Contract
{
    public class PriceMapResponse
    {
        public List<HouseInformation> Houses { get; set; }
    }

    public class HouseInformation
    {
        public string XCoordinates { get; set; }
        public string YCoordinates { get; set; }
        public string CostGroupRange { get; set; }
    }
}
