using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Tasks;
using Core.Users;
using Humanizer;
using NUnit.Framework;

namespace Infrastructure.Tests
{
    public class TaskProviderTests
    {
        [Test]
        public async void Should_Add_Task_To_Index()
        {
            var userId = Guid.NewGuid();
            var TaskProvider = new TaskProvider();
            Core.Tasks.Task task = new Core.Tasks.Task();
            task.DueDate = DateTime.Now;
            task.Description = "A fancy test task";
            task.TaskState = State.Draft;
            task.Users = new List<Guid>() {userId};

            Guid result = await TaskProvider.CreateTask(task);

            Assert.AreEqual(result, task.TaskId);
        }
    }
}
