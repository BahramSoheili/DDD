using HUGHUBLib.ValueObjetcs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHUGHUB
{
    public class PriceService
    {
        public static string 
            url = "https://localhost:44365/person";
        public PersonData GetPerson()
        {
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
            return person;
        }
        public async Task<string> GetPrice(PersonData person)
        {
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            string price = response.Content.ReadAsStringAsync().Result;
            return price;
        }
    }
}
