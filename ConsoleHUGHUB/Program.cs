using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HUGHUBLib.ValueObjetcs;
using Newtonsoft.Json;

namespace ConsoleHUGHUB
{
    class Program
    {       
        static void Main(string[] args)
        {
            int tax = 0;
            string insurer = "";
            string error = "";
            PriceService priceService = new PriceService();
            PersonData person = priceService.GetPerson();
            string price = priceService.GetPrice(person).Result;
            if (price == "-1")
            {
                Console.WriteLine(String.Format("There was an error - {0}", error));
            }
            else
            {
                Console.WriteLine(String.Format("You price is {0}, from insurer: {1}. This includes tax of {2}", price, insurer, tax));
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
