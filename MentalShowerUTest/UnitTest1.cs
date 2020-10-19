using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ModelLib.Models;
using System.Linq;
using ApiMentalShowerIndoor.Controllers;

namespace MentalShowerUTest
{
    [TestClass]
    public class UnitTest1
    {
        //arrange
        private List<SensorDataModel> _testList;
        private IndoorClimateController _controller = new IndoorClimateController();
        [TestInitialize]
        public void TestInitialize()
        {

            //har du opdateret vs?
            _testList = new List<SensorDataModel>();
            //act
            foreach (var item in IndoorClimateController.data)
            {
                _testList.Add(item);
            }
        }

        //assert
        [TestMethod]
        public void TestGet()
        {
            var controllerList = _controller.Get();
           
            Assert.AreEqual(_testList.Count(), controllerList.Count());


        }
    }
}
