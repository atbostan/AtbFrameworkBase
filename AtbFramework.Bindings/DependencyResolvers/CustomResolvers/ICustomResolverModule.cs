﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AtbFramework.Bindings.Interfaces.DependencyResolver
{
    public interface ICustomResolverModule
    {
        void Load(IServiceCollection serviceCollection);

    }
}
