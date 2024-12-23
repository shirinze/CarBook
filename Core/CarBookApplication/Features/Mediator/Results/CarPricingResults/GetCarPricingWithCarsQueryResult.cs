using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarsQueryResult
    {
        public int CarId { get; set; }
        public int CarPricingID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Amount { get; set; }
    }
}
