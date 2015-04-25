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
