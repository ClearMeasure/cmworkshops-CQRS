using System;
using System.Threading.Tasks;
using System.Web.Http;
using ShortBus;
using ShortBus.StructureMap;
using StructureMap;

namespace API.Application
{
    
    public abstract class ApiControllerBase : ApiController
    {
        public IMediator Mediator { get; set; }

        protected async Task<T> QueryAsync<T>(IAsyncRequest<T> query)
        {
            var result = await Mediator.RequestAsync(query);
           
            return result;
        }
        
        protected async Task<T> CommandAsync<T>(IAsyncRequest<T> command)
        {
            var result = await Mediator.RequestAsync(command);

            return result;
        }
    }
}