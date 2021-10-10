using Core.Aggregates;
using System;
using HUGHUBLib.ValueObjetcs;

namespace DomainHUGHUP
{
    internal class Person : Aggregate
    {
        public PersonData Data { get; private set; }
        public Person()
        {

        }
    }
}