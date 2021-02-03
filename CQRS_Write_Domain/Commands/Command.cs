using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Domain.Commands
{
    public class Command : ICommand
    {
        public string Type
        {
            get { return this.GetType().Name; }
        }
    }
}
