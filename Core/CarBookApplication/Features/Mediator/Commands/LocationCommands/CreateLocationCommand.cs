using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommand:IRequest
    {
        public string Name { get; set; }
    }
}
