using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class TaskProvider : ElasticSearchProvider
    {
        public async Task<Guid> CreateTask(Core.Tasks.Task task)
        {
            Guid id = Guid.NewGuid();
            task.TaskId = id;

            var result = await Save("task", id, JsonConvert.SerializeObject(task));

            return id;
        }
    }
}
