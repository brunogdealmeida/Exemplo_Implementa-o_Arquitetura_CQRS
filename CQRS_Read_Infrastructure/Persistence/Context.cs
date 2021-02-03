using CQRS_Read_Infrastructure.Persistence.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Read_Infrastructure.Persistence
{
    public class Context: IContext
    {
        public IPersonRepository People { get; set; }
        public Context(IPersonRepository personRepository) 
        {
            this.People = personRepository;
        }

        
    }
}
