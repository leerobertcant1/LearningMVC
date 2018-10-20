using Autofac.Extras.Moq;
using LearningMVC.Controllers.Web_API;
using LearningMVC.Data;
using LearningMVC.Models.Web_APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearningMVC.Tests.Controllers
{
    public class XUnitTests
    {
        //UnitofworkStateundertestExecuted
        [Fact]
        public void GetData_GetAllFoodData_ListOfData()
        {
            //arrange
            using (var mock = AutoMock.GetLoose())
            {
                //act
                mock.Mock<FoodRepository>()
                    .Setup(f => f.GetFoods());

                var controller = mock.Create<FoodsController>();
                var expected = controller.Get();
                
                //assert
                Assert.True(expected == null);
            }  
        }
    }
}
