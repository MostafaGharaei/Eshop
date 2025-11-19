using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities.BaseEntities;

namespace IDP.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FullName { get; set; }
        public required string CodeNumber { get; set; }

    }
}
