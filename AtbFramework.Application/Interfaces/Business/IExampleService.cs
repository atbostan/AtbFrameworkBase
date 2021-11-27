using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.DTOs;
using AtbFramework.Domain.Entities;

namespace AtbFramework.Application.Interfaces.Business
{
    public interface IExampleService:IBaseService<ExampleClass,int, ExampleDto>
    {
    }
}
