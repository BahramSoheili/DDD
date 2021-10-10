using DomainHUGHUP.Handlers.QueryHandlers;
using DomainHUGHUP.Queries;
using HUGHUBLib.ValueObjetcs;
using System;
using Xunit;

namespace Xunit
{
    public class UnitTest1
    {
        PersonQueryHandler personQueryHandler =
            new PersonQueryHandler();
        [Fact]
        public void GetQuotationSystem1Test()
        {
            int expected = 34;
            //Arrange
            var person = new PersonData()
            {
                riskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                },
                tax = 0,
                insurer = "",
                error = "",
            };
            GetPrice getPrice = new GetPrice(person);
            var result = personQueryHandler.GetQuotationSystem1(getPrice);
            //Assert
            Assert.Equal(result, expected);
        }
        public void GetQuotationSystem2Test()
        {
            int expected = 34;
            //Arrange
            var person = new PersonData()
            {
                riskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "examplemake1",
                    Value = 500
                },
                tax = 0,
                insurer = "",
                error = "",
            };
            GetPrice getPrice = new GetPrice(person);
            var result = personQueryHandler.GetQuotationSystem2(getPrice);
            //Assert
            Assert.Equal(result, expected);
        }
        public void GetQuotationSystem3Test()
        {
            int expected = 34;
            //Arrange
            var person = new PersonData()
            {
                riskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                },
                tax = 0,
                insurer = "",
                error = "",
            };
            GetPrice getPrice = new GetPrice(person);
            var result = personQueryHandler.GetQuotationSystem3(getPrice);
            //Assert
            Assert.Equal(result, expected);
        }
        // we can add more unit test for console as well
    }
}
