using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;

namespace Core.Commands.AddTaskCommand
{
    public class AddTaskCommandHandler : IAsyncRequestHandler<AddTaskCommand, AddTaskResult>
    {

        public Task<AddTaskResult> HandleAsync(AddTaskCommand request)
        {
            var reponse = new AddTaskResult(Guid.NewGuid());

            return Task.FromResult(reponse);
        }
    }
}
