using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;

namespace AtbFramework.Domain.Entities
{
    public class ExampleClass: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
    }
}
