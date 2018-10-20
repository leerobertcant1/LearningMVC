using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningMVC.Controllers;
using LearningMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using FluentAssertions;
using LearningMVC.Services;
using LearningMVC.Data;

//End To end - entire system
//Integration, database ad UI
//Unit single areas
namespace LearningMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private TestController _testController;

        public HomeControllerTests()
        {
            _testController = new TestController();
        }

        [TestMethod]
        public void Text_LeeCant_NameLeeCant()
        {
            About model = new About();

            model.Name = "Lee Cant";

            Assert.AreEqual("Lee Cant", model.Name);
        }

        [TestMethod]
        public void StringLength_Number5_Length5()
        {
            string five = "five_";

            int length = five.Length;

            Assert.AreEqual(length, 5);
        }

        [TestMethod] //Autopasses
        public void BasicTest_NoAssert_PassesRegardless()
        {
            string useless = "five_";
        }

        [TestMethod]//Output verification / Functional - Maths only. 
                    //Try to use the most
        public void Add_1and2_3()
        {
            int a = 1;
            int b = 2;

            int result = a + b;

            Assert.AreEqual(3, result);
        }

        [TestMethod]//Verifies the state of this list. False positives could happen.
        public void List_StringType_HasType()
        {
            IList<string> list = new List<string>();

            list.Add("list item");

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void GetText_Null_NullValue()
        {
            string text;

            text = null;

            Assert.IsNull(text);
        }

        //Rhinomocks stuff below
        public class HandRolled
        {
            private string _setter;

            public HandRolled(string setter)
            {
                _setter = setter;
            }

            public string GetSetter()
            {
                return _setter;
            }
        }

        //Creates an instance that can ve re-used, where construct the classes manually.
        [TestMethod]
        public void RhinoMocks_HandrolledMockObject_Set_Data_Should_Match()
        {
            //Arrange
            var setData = "SetData";
            var handRolled = new HandRolled(setData);

            //Act
            var returnedValue = handRolled.GetSetter();

            //Assert
            returnedValue.Should().Be(setData);
        }

        //Very useful for DI stuff to check when functions are hit.
        //Need to Mock out an interface when doing this.
        [TestMethod]
        public void RhinoMocks_Mock_Object_Checking_Injected_Function_Call()
        {
            //Not an instance of the class, this is used when injected.
            var dependencyInjectorServiceMock = MockRepository.GenerateMock<IDependencyInjectorService>();

            var diRepository = new DI_Repostitory(dependencyInjectorServiceMock);

            var data = diRepository.GetData();

            dependencyInjectorServiceMock.AssertWasCalled( x=> x.DependencyInjectionTest());
            dependencyInjectorServiceMock.VerifyAllExpectations();
        }

        //Useful with UIs for when views set
        [TestMethod]
        public void RhinoMocks_Mock_Object_Checking_Injected_Attribute_Set()
        {
            //Not an instance of the class, this is used when injected.
            var dependencyInjectorServiceMock = MockRepository.GenerateMock<IDependencyInjectorService>();

            var diRepository = new DI_Repostitory(dependencyInjectorServiceMock);

            var setData = true;

            diRepository.SetData(setData);

            dependencyInjectorServiceMock.AssertWasCalled(x => x.DependencyInjectionAttributeTest(setData));
            dependencyInjectorServiceMock.VerifyAllExpectations();
        }

        //Stub tells actions what to return.
        //Mock just listens out encase it is called.
        [TestMethod]
        public void RhinoMocks_Stub_Data_Should_Be_()
        {
            //Arrange
            var dependencyInjectorServiceMock = MockRepository.GenerateMock<IDependencyInjectorService>();
            dependencyInjectorServiceMock.Stub( x => x.DependencyInjectionTest()).Return("Data");

            var diRepository = new DI_Repostitory(dependencyInjectorServiceMock);

            //Act
            var data = diRepository.GetData();

            //Assert
            data.Should().Be("Data");
        }

    } 
}

