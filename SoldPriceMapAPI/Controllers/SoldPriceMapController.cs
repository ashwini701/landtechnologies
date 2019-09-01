using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoldPriceMapAPI.Contract;
using SoldPriceMapAPI.Service;

namespace SoldPriceMapAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1")]
    public class SoldPriceMapController : Controller
    {
        private ISoldPriceMapService _soldPriceMapService;
        public SoldPriceMapController(ISoldPriceMapService soldPriceMapService)
        {
            _soldPriceMapService = soldPriceMapService;
        }

        [HttpGet]
        [Route("SoldPriceMapData")]
        public async Task<PriceMapResponse> SoldPriceMapData()
        {
            return _soldPriceMapService.GetSoldPriceMapData();
        }
            
    }
}