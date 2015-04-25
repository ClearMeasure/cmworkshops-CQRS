using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class TasksController : ApiController
    {
        // GET api/tasks
        public IEnumerable<Task> Get()
        {
            return new List<Task>() {new Task()};
        }

        // GET api/tasks/5
        public Task Get(int id)
        {
            return new Task();
        }

        // POST api/tasks
        public void Post([FromBody]Task value)
        {
        }

        // PUT api/tasks/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
