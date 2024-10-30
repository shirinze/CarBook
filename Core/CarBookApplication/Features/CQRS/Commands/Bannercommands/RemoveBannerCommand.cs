using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Commands.Bannercommands
{
    public class RemoveBannerCommand
    {
        public int Id { get; set; }

        public RemoveBannerCommand(int id)
        {
            Id = id;
        }
    }
}
