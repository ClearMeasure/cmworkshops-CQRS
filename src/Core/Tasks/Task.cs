using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Users;

namespace Core.Tasks
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public List<User> Users { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public List<string> Comments { get; set; }
        public State TaskState { get; set; }
    }
}
