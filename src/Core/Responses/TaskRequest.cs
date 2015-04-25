using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tasks;
using Core.Users;

namespace Core.Responses
{
    public class TaskRequest
    {
        public TaskRequest(Task task)
        {
            Users = task.Users;
            Description = task.Description;
            DueDate = task.DueDate;
            CompletedDate = task.CompletedDate;
            Comments = task.Comments;
            TaskState = task.TaskState;
        }
        List<Guid> Users { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public List<string> Comments { get; set; }
        public State TaskState { get; set; }
    }
}
