using CQRS_Read_Infrastructure.Persistence.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Read_Infrastructure.Persistence
{
    public interface IContext
    {
        IPersonRepository People { get; set; }
    }
}
