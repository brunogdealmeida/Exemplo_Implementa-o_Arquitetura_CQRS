using CQRS_Write_Domain.People;
using CQRS_Write_Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Application.People
{
    public class PersonCreateCommand : Command
    {
        public PersonClass Class { get; set;  }
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonCreateCommand(PersonClass personClass, string name, int age)
        {
            this.Class = personClass;
            this.Name = name;
            this.Age = age;
        }
    }
}
