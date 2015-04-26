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
                s.AddAllTypesOf(typeof(ShortBus.IAsyncRequestHandler<,>));
                s.AddAllTypesOf(typeof(ShortBus.INotificationHandler<>));
            }));   
        }
    }
}
