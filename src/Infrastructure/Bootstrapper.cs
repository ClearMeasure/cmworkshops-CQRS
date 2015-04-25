using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using StructureMap;
using StructureMap.Graph;

namespace Infrastructure
{
    public class Bootstrapper
    {
        public void Start()
        {
            ObjectFactory.Initialize(i => i.Scan(s =>
            {
                s.AssemblyContainingType<IMediator>();
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AddAllTypesOf(typeof(IQueryHandler<,>));
                s.AddAllTypesOf(typeof(ICommandHandler<>));
            }));   
        }
    }
}
