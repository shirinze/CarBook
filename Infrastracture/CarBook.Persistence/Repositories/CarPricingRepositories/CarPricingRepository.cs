using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.CarPricingInterfaces;
using CarBookApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {

            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(s=>s.PricingID==2).ToList();
            return values;
        }

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from (select Model,CoverImageUrl,PricingID,Amount from CarPricings inner join Cars on Cars.CarID=CarPricings.CarID inner join Brands on Brands.BrandID=Cars.BrandID) as sourcetabel pivot(sum(Amount) for PricingID In([2],[3],[5])) as pivottable;";
                command.CommandType=System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carpricingviewmodel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                           CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amount=new List<decimal>
                            {
                                Convert.ToDecimal(reader["2"]),
                                Convert.ToDecimal(reader["3"]),
                                Convert.ToDecimal(reader["5"])
                            }

                        };
                       
                        values.Add(carpricingviewmodel);
                    }
                }
                _context.Database.CloseConnection();
                return values;

            }
		}
	}
}
