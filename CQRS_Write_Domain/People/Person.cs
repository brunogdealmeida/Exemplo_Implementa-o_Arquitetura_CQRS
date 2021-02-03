using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Domain.People
{
    public class Person : AggregateRoot<int>
    {
        public PersonType Class { get; protected set; }
        public Person() { }
        public Person(int id, PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.ApplyChange(new PersonCreatedEvent(id, personClass, name, age));
        }

        public Person(PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.ApplyChange(new PersonCreatedEvent(0, personClass, name, age));
        }

        public void Rename(string name)
        {
            this.ApplyChange(new PersonRenamedEvent(this.Id, name));
        }

        public void Delete()
        {
            this.ApplyChange(new PersonDeletedEvent(this.Id));
        }

        private void Apply(PersonRenamedEvent @event)
        {
            this.Id = @event.AggregateId;
            this.Class = new PersonType(this.Class.Class, @event.Name, this.Class.Age);
        }

        public override string ToString()
        {
            return $"{this.Class.Name}: [Class]{this.Class}, [Name]{Class.Name}, [Age]{Class.Age}";
        }
    }
}
