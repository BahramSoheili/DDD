using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Core.Aggregates
{
    public abstract class Aggregate: IAggregate
    {
        public int Version { get; protected set; }

        public Guid Id { get; protected set; }

       //for serialization purposes
        protected Aggregate() { }
    }
}
