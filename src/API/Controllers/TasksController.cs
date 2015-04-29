using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Application;
using Core.Commands.AddTaskCommand;
using Core.Responses;
using Core.Users;
using LightSail.Api.ActionResults;
using ShortBus;
using Task = Core.Tasks.Task;

namespace API.Controllers
{
    [Route("api/tasks")]
    public class TasksController : ApiControllerBase
    {
     
        [HttpGet]
        [ResponseType(typeof(IEnumerable<TaskResponse>))]
        public IEnumerable<Task> Get()
        {
            return new List<Task>() {new Task()};
        }

        [HttpGet]
        [Route("{id:guid}", Name = "Get")]
        [ResponseType(typeof(TaskResponse))]
        public Task Get(Guid id)
        {
            return new Task();
        }

        [HttpGet]
        [ResponseType(typeof(TaskResponse))]
        public Task Get(User user)
        {
            return new Task();
        }

        [HttpPost]
        [ResponseType(typeof(AcceptedResult))]
        public async Task<IHttpActionResult> Post([FromBody]AddTaskCommand cmd)
        {
            var response = await CommandAsync(cmd);
            
            var uri = new Uri(Url.Link("Get", new { id = response.TaskId }));
            return new AcceptedResult(Request, uri);
        }

        [HttpPut]
        [Route("{id:guid}/publish")]
        public void Put(Guid id)
        {
        }

        [HttpPut]
        [Route("{id:guid}/cancel")]
        public void Cancel(Guid id)
        {
        }

        [HttpPut]
        [Route("{id:guid}/accept")]
        public void Accept(Guid id)
        {
        }

        [HttpPut]
        [Route("{id:guid}/complete")]
        public void Complete(Guid id)
        {
        }

    }
}
