using System;
using LearningMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//[UnitOfWork__StateUnderTest__ExpectedBehavior]

//write tests based on what i should do for functionality.
//Get test working first it should fail.
//Then do simple thing to pass.
//Refactor so it make sense.
namespace LearningMVC.Tests.Features
{
    [TestClass]
    public class AgeTests
    {
        [TestMethod]
        public void CalculateYear_AgeIs20_1998()
        {
            var person = new Person { FirstName = "Test", LastName = "Test", Age = 20};

            var ageCalculator = new AgeYearCalculator();
            var yearOfBirth = ageCalculator.CalculateYearOfBirth(person.Age);

            Assert.AreEqual(1998, yearOfBirth);
        }

        [TestMethod]
        public void CalculateAge_AgeIs15_LessThan18()
        {
            var person = new Person { FirstName = "Test", LastName = "Test", Age = 15 };

            var ageCalculator = new AgeYearCalculator();
            var yearOfBirth = ageCalculator.CalculateYearOfBirth(person.Age);

            Assert.IsTrue(yearOfBirth > 2000);
        }

        [TestMethod]
        public void CalculateAge_AgeIs20_GreaterThan18()
        {
            var person = new Person { FirstName = "Test", LastName = "Test", Age = 20 };

            var ageCalculator = new AgeYearCalculator();
            var yearOfBirth = ageCalculator.CalculateYearOfBirth(person.Age);

            Assert.IsTrue(yearOfBirth < 2000);
        }
    }

    internal class AgeYearCalculator
    {
        public AgeYearCalculator()
        {
        }

        internal int CalculateYearOfBirth(int age)
        {
            int year = 2018 - age;

            return year;
        }
    }
}
