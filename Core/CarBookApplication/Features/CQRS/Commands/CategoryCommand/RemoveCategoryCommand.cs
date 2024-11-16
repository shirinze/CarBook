using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Commands.CategoryCommand
{
    public class RemoveCategoryCommand
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
