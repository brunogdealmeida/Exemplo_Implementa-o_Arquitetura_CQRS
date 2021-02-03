using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Domain.People
{
    public class PersonCreatedEvent : Event
    {
        public PersonClass Class { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonCreatedEvent(int aggregateId, PersonClass personClass, string name, int age)
        {
            this.AggregateId = aggregateId;
            this.Class = personClass;
            this.Name = name;
            this.Age = age;
        }
    }
}
