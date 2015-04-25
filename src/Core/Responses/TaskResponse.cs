using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tasks;
using Core.Users;

namespace Core.Responses
{
    public class TaskResponse
    {
        public TaskResponse(Task task)
        {
            TaskId = task.TaskId;
            Users = task.Users;
        }
        public int TaskId { get; set; }
        List<User> Users { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public List<string> Comments { get; set; }
        public State TaskState { get; set; }
    }
}
