using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCommand:IRequest
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public int CarID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
    }
}
