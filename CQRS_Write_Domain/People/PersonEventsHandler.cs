using CQRS_Read_Application.People;
using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Domain.People
{
    public class PersonEventsHandler : IEventHandler<PersonCreatedEvent>, IEventHandler<PersonDeletedEvent>
    {
        private readonly IPersonService personService;

        public PersonEventsHandler(IPersonService personService)
        {
            this.personService = personService;
        }
        public void Handle(PersonDeletedEvent @event)
        {
            this.personService.Delete(@event.AggregateId);
        }
        public void Handle(PersonRenamedEvent @event)
        {
            var person = this.personService.Find(@event.AggregateId);
            person.Name = @event.Name;
            this.personService.Update(person);

        }

        public void Handle(PersonCreatedEvent @event)
        {
            CQRS_Read_Infrastructure.Persistence.People.Person person =
                new CQRS_Read_Infrastructure.Persistence.People.Person
                (@event.AggregateId, (CQRS_Read_Infrastructure.Persistence.People.PersonClass)
                (@event.Class), @event.Name, @event.Age);

            this.personService.Insert(person);
        }
    }
}
