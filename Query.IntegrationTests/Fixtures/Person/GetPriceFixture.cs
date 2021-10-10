using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Testing;
using FluentAssertions;
using HUGHUB.API;
using HUGHUBLib.ValueObjetcs;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Query.IntegrationTests.Person
{
    public class GetPriceFixture : ApiFixture<Startup>
    {
        public const string  queryAddress = "Query.Api";
        public override string ApiUrl { get; } = QueryUrls.PersonsUrl;

        public readonly Guid Id = Guid.NewGuid();
        public readonly PersonData Data = new PersonData()
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
        public override async Task InitializeAsync()
        {
            // prepare event
            var @event = new PersonCreatedPending(
                Id,
                Data,
                true,
                DateTime.Now,
                DateTime.Now
            );

            // send meeting created event to internal event bus
            await Sut.PublishInternalEvent(@event);
        }
    }   
}
