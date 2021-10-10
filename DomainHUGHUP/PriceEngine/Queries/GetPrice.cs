using Core.Queries;
using HUGHUBLib.ValueObjetcs;

namespace DomainHUGHUP.Queries
{
    public class GetPrice : IQuery<decimal>
    {
        public PersonData Data { get; set; }
        public GetPrice(PersonData data)
        {
            Data = data;
        }
    }
}

