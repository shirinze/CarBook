using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.ViewModels
{
	public class CarPricingViewModel
	{
        public CarPricingViewModel()
        {
            Amount = new List<decimal>();
        }
        public string Model { get; set; }
        public List<Decimal> Amount { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
