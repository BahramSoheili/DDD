using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Testing;
using FluentAssertions;
using Query.Api;
using QueryManagement.DeviceManager.Events.Pendings.Created;
using QueryManagement.DeviceManager.SearchObjects;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Query.IntegrationTests.Person
{   
    [Order(2)]
    public class GetPriceTests : IClassFixture<GetPriceFixture>
    {
        private readonly GetPriceFixture fixture;
        public GetPriceTests(GetPriceFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        [Trait("Category", "Exercise")]
        public async Task PersonCreated_ShouldUpdateReadModel()
        {
            //send query
            await Task.Delay(1000);
            var queryResponse = await fixture.Client.GetAsync($"{QueryUrls.PersonsUrl}");
            queryResponse.EnsureSuccessStatusCode();

            var queryResult = await queryResponse.Content.ReadAsStringAsync();
            queryResult.Should().NotBeNull();

            var persons = queryResult.FromJson<IReadOnlyCollection<QueryManagement.DeviceManager.Person>>();
            persons.Should().Contain(person => person.Id == fixture.Id &&
            person.Data.personLastname == fixture.Data.personLastname &&
            person.Data.personFirstname == fixture.Data.personFirstname &&
            person.Data.devision == fixture.Data.devision &&
            person.Data.email == fixture.Data.email &&
            person.Data.birthDate == fixture.Data.birthDate &&
            person.Data.mobile == fixture.Data.mobile &&
            person.Data.description == fixture.Data.description);
        }
    }
}
