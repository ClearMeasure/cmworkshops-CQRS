using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Responses;
using Core.Tasks;
using Core.Users;
using LightSail.Api.ActionResults;

namespace API.Controllers
{
    [Authorize]
    [Route("api/tasks")]
    public class TasksController : ApiController
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
        public IHttpActionResult Post([FromBody]TaskRequest value)
        {
            Guid savedTaskId = Guid.NewGuid(); // We need to save the object here or send the command and get the id to return via the Url.Link
            var uri = new Uri(Url.Link("Get", new { id = savedTaskId }));
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
