using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Interfaces.DTO;

namespace AtbFramework.Application.Business.Queries.QueryFilterEntities
{
    public class ExampleEntityFilter:IFilterDto
    {
        public int? Id { get; set; }
        public string City { get; set; }
        public Guid MockId { get; set; }
    }
}
