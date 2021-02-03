using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Domain.People
{
    public struct PersonType
    {
        public PersonClass Class { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public PersonType(PersonClass personClass, string name, int age)
        {
            this.Class = personClass;
            this.Name = name;
            this.Age = age;
        }
    }
}
