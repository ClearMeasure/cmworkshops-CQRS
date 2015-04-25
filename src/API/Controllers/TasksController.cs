using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        [ResponseType(typeof(TaskResponse))]
        public Task Get(int id)
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
            var savedTaskId = Guid.NewGuid(); // We need to save the object here or send the command and get the id to return via the Url.Link
            var uri = new Uri(Url.Link("Get", new { id = savedTaskId }));
            return new AcceptedResult(Request, uri);
        }

        [HttpPut]
        [Route("{guid:id}/publish")]
        public void Put(int id)
        {
        }

        [HttpPut]
        [Route("{guid:id}/cancel")]
        public void Cancel(int id)
        {
        }

        [HttpPut]
        [Route("{guid:id}/accept")]
        public void Accept(int id)
        {
        }

        [HttpPut]
        [Route("{guid:id}/complete")]
        public void Complete(int id)
        {
        }

    }
}
