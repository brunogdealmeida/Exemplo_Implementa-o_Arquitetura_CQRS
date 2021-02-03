using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CQRS_Read_Infrastructure.Persistence.People
{
    [Flags]
    public enum PersonClass
    {
        Comum,
        Admin
    }
    public class Person
    {
        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PersonClass Class { get; set; }
        public string Name { get; set;  }
        public int Age { get; set; }

        public Person(int id, PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            this.Id = id;
            this.Class = personClass;
            this.Name = name;
            this.Age = age;
        }

        public Person(PersonClass personClass, string name, int age)
        {
            this.Id = -1;
            this.Class = personClass;
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Class}:[Class] {this.Class}, [Name]{this.Name}, [Age]{this.Age}";
        }
    }
}
