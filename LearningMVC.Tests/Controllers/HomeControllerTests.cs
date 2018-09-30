using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningMVC.Controllers;
using LearningMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

//End To end - entire system
//Integration, database ad UI
//Unit single areas
namespace LearningMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
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

        [TestMethod]
         public void Sql_GetsRecords_RecordsReturned()
        {
            var _db = new Mock<LearningDB>();

            var model = _db.Object.People;
                                                                                                                                                                                             
            Assert.IsNotNull(model);
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

        [TestMethod]//Collaborator test, needs to happen in order
        public void SqlSaveToDb_RandomPerson_Saved()
        {
            Person person = new Person();
            var _db = new Mock<LearningDB>();

            person.Id = Guid.NewGuid();
            person.FirstName = "Unit Test";
            person.LastName = "Unit test";

            _db.Object.People = new LearningDB().People;
            _db.Object.People.Add(person);
            _db.Object.SaveChanges();

            Person model = _db.Object.People.Find(person.Id);

            Assert.AreEqual(model.Id, person.Id);
        }

        [TestMethod]
        public void GetText_AnyString_TextReturned()
        {
            var controller = new TestController();
            var mock = new Mock<TestController>();

            controller.ReturnEmptyString("");
            mock.Setup(x => x.ReturnEmptyString(It.IsAny<string>())).Returns((string x) => "value");
            string result = mock.Object.ReturnEmptyString();
                                         
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetText_Null_NullValue()
        {
            string text;

            text = null;

            Assert.IsNull(text);
        }
    } 
}

