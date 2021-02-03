using CQRS_Read_Application.People;
using CQRS_Write_Domain.Commands;
using CQRS_Write_Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS_Write_Application.People
{
    public class PersonCommandHandler : ICommandHandler<PersonCreateCommand>,
        ICommandHandler<PersonDeleteCommand>, ICommandHandler
    {
        private readonly ICommandEventRepository eventRepository;
        private readonly IPersonService personService;

        public PersonCommandHandler(IPersonService personService, ICommandEventRepository eventRepository)
        {
            this.personService = personService;
            this.eventRepository = eventRepository;
        }

        public void Handle(PersonCreateCommand command)
        {
            Person person = new Person(this.personService.GetAll().Count() + 1, 
                command.Class, command.Name, command.Age);

            this.eventRepository.Save(person);
        }

        public void Handle(PersonRenameCommand command)
        {
            Person person = this.eventRepository.GetByCommandId<Person>(command.Id);
            person.Rename(command.Name);
            this.eventRepository.Save(person);
        }

        public void Handle(PersonDeleteCommand command)
        {
            Person person = this.eventRepository.GetByCommandId<Person>(command.Id);
            person.Delete();
            this.eventRepository.Save(person);
        }
    }
}
