using AtbFramework.Application.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Application.DTOs
{
    public class ExampleDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public Guid? MockId { get; set; }
    }
}
