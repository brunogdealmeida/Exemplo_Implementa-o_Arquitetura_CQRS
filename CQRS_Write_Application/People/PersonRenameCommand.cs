using CQRS_Write_Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Application.People
{
    public class PersonRenameCommand : Command
    {
        public int Id { get; }
        public string Name { get; }
        public PersonRenameCommand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
