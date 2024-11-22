using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudCommand(int id)
        {
            Id = id;
        }
    }
}
