using Moq;
using SoldPriceMapAPI.Contract;
using SoldPriceMapAPI.Infrastructure;
using SoldPriceMapAPI.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace SoldPriceMap.UnitTests
{
    public class SoldPriceMapServiceShould
    {
        private readonly Mock<IReadContent> _readContentMock;
        public SoldPriceMapServiceShould()
        {
            _readContentMock = new Mock<IReadContent>();
        }
        [Fact]
        public void ReturnSoldPriceMapData()
        {
            //  HouseData houseData = new HouseData();
            List<HouseData> HouseData = new List<HouseData>() {
                new HouseData (){
                    XCoordinates="60",
                    YCoordinates="23",
                    Price= 123456
                },
                  new HouseData (){
                    XCoordinates="30",
                    YCoordinates="70",
                    Price= 423456
                }
            };
            _readContentMock.Setup(x => x.GetFileContent())
                .Returns(HouseData);

            SoldPriceMapService soldPriceMapService = new SoldPriceMapService(_readContentMock.Object);
            var result= soldPriceMapService.GetSoldPriceMapData();
            
            Assert.True(result.Houses[0].CostGroupRange == "1");

        }
    }
}
