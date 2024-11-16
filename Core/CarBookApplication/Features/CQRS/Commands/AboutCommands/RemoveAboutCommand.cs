using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {

        public int Id { get; set; }

        public RemoveAboutCommand(int id)
        {
            Id = id;
        }
    }
}
