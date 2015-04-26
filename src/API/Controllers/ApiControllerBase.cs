using System;
using System.Threading.Tasks;
using System.Web.Http;
using ShortBus;

namespace API.Controllers
{
    
    public abstract class ApiControllerBase : ApiController
    {
        public IMediator Mediator { get; set; }

        protected Response<TResult> Query<TResult>(IRequest<TResult> query)
        {
            return Mediator.Request(query);
        }

        protected async Task<Response<T>> QueryAsync<T>(IAsyncRequest<T> query)
        {
            return await Mediator.RequestAsync(query);
        }

        protected void Command<T>(T command)
        {
            Mediator.Notify(command);
        }

        protected async Task<Response<T>> CommandAsync<T>(IAsyncRequest<T> command)
        {
            var result = await Mediator.RequestAsync(command);
            if (result.HasException())
            {
                throw result.Exception;
            }
            return result;
        }
    }

    //public interface IMediatorWrapper
    //{
    //    Response<TResult> Request<TResult>(IRequest<TResult> query);
    //    Task<Response<T>> RequestAsync<T>(IAsyncRequest<T> query);

    //    Task<Response<T>> Notify<T>(IAsyncRequest<T> command);
    //    void Notify<T>(T command);
    //}
}