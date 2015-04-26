using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Responses;
using Core.Tasks;
using ShortBus;

namespace Core.Commands.AddTaskCommand
{
    public class AddTaskCommand : IAsyncRequest<AddTaskResult>
    {
        List<Guid> Users { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public List<string> Comments { get; set; }
        public State TaskState { get; set; }

        public AddTaskCommand()
        {
            Users = new List<Guid>();
            Comments = new List<string>();
            TaskState = State.Draft;
        }

        public AddTaskCommand(Task task)
        {
            Users = task.Users;
            Description = task.Description;
            DueDate = task.DueDate;
            CompletedDate = task.CompletedDate;
            Comments = task.Comments;
            TaskState = task.TaskState;
        }
    }

    public class AddTaskResult
    {
        public AddTaskResult(Guid taskId)
        {
            TaskId = taskId;
        }
        public Guid TaskId { get; set; }
    }
}
