using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Tasks;
using Core.Users;

namespace API.Controllers
{
    [Authorize]
    [Route("api/tasks")]
    public class TasksController : ApiController
    {
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return new List<Task>() {new Task()};
        }

        [HttpGet]
        public Task Get(int id)
        {
            return new Task();
        }

        [HttpGet]
        public Task Get(User user)
        {
            return new Task();
        }

        [HttpPost]
        public void Post([FromBody]Task value)
        {
            
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
