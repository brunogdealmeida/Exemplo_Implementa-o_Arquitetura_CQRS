using CQRS_Write_Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Application
{
    public class PersonDeleteCommand : Command
    {
        public int Id { get; set; }
        public PersonDeleteCommand(int id)
        {
            this.Id = id;
        }
    }
}
