using Core.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;
using DomainHUGHUP.Queries;
using System.Dynamic;

namespace DomainHUGHUP.Handlers.QueryHandlers
{
    public class PersonQueryHandler
        : IQueryHandler<GetPrice, decimal>        
    {
        public PersonQueryHandler()
        {
        }  
        public Task<decimal> Handle(GetPrice request, CancellationToken cancellationToken)
        {
            //initialise return variables
            decimal price = 0;
            var tax = 0;
            var insurerName = "";
            var errorMessage = "";
            if (request.Data.riskData.DOB != null)
            {
                price = GetQuotationSystem1(request);
                
            }
            //system 2 only quotes for some makes

            if(request.Data.riskData.Make == "examplemake1" 
                || request.Data.riskData.Make == "examplemake2" 
                || request.Data.riskData.Make == "examplemake3")
            {
                price = GetQuotationSystem2(request);             
            }
            //system 3 is always called
            price = GetQuotationSystem3(request); 
            if (price == 0)
            {
                price = -1;
            }
            return Task.FromResult(price);
        }

        public dynamic GetQuotationSystem2(GetPrice request)
        {
            var price = 0;
            var tax = 0;
            var insurerName = "";
            dynamic systemRequest2 = new ExpandoObject();
            systemRequest2.FirstName = request.Data.riskData.FirstName;
            systemRequest2.LastName = request.Data.riskData.LastName;
            systemRequest2.Make = request.Data.riskData.Make;
            systemRequest2.Value = request.Data.riskData.Value;

            QuotationSystem2 system2 = new QuotationSystem2("http://quote-system-2.com", "1235", systemRequest2);

            dynamic system2Response = system2.GetPrice();
            if (system2Response.HasPrice && system2Response.Price < price)
            {
                price = system2Response.Price;
                insurerName = system2Response.Name;
                tax = system2Response.Tax;
            }
            return price;
        }

        public dynamic GetQuotationSystem1(GetPrice request)
        {
            var price = 0;
            var tax = 0;
            var insurerName = "";
            QuotationSystem1 system1 = new QuotationSystem1("http://quote-system-1.com", "1234");
            dynamic systemRequest1 = new ExpandoObject();
            systemRequest1.FirstName = request.Data.riskData.FirstName;
            systemRequest1.Surname = request.Data.riskData.LastName;
            systemRequest1.DOB = request.Data.riskData.DOB;
            systemRequest1.Make = request.Data.riskData.Make;
            systemRequest1.Amount = request.Data.riskData.Value;

            dynamic system1Response = system1.GetPrice(systemRequest1);
            if (system1Response.IsSuccess)
            {
                price = system1Response.Price;
                insurerName = system1Response.Name;
                tax = system1Response.Tax;
            }
            return price;
        }

        public dynamic GetQuotationSystem3(GetPrice request)
        {
            var price = 0;
            var tax = 0;
            var insurerName = "";
            QuotationSystem3 system3 = new QuotationSystem3("http://quote-system-3.com", "100");
            dynamic systemRequest3 = new ExpandoObject();

            systemRequest3.FirstName = request.Data.riskData.FirstName;
            systemRequest3.Surname = request.Data.riskData.LastName;
            systemRequest3.DOB = request.Data.riskData.DOB;
            systemRequest3.Make = request.Data.riskData.Make;
            systemRequest3.Amount = request.Data.riskData.Value;

            var system3Response = system3.GetPrice(systemRequest3);
            if (system3Response.IsSuccess && system3Response.Price < price)
            {
                price = system3Response.Price;
                insurerName = system3Response.Name;
                tax = system3Response.Tax;
            }
            return price;
        }

    }
}

