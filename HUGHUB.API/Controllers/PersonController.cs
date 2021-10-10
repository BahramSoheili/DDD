using Core.Queries;
using DomainHUGHUP.Queries;
using HUGHUBLib.ValueObjetcs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HUGHUB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        public PersonController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }
        public PersonController()
        {
        }
        [HttpPost]
        public Task<decimal> Post([FromBody] PersonData data)
        {
            try
            {
                var res = _queryBus.Send<GetPrice, decimal>
                   (new GetPrice(data));
                return res;
            }
            catch (Exception e)
            {
                throw new Exception("Error.");
            }
        }
    }
}
