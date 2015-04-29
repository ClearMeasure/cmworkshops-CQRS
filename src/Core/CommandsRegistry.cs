using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Core
{
    public class CommandsRegistry : Registry
    {
        public CommandsRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<CommandsRegistry>();
                x.AddAllTypesOf(typeof(ShortBus.IAsyncRequestHandler<,>));
                x.AddAllTypesOf(typeof(ShortBus.IAsyncNotificationHandler<>));
            });

            Debug.WriteLine(ObjectFactory.Container.WhatDoIHave());
        }
    }
}
