using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.StatisticsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string GetBrandNameByMaxChar()
        {
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //select AVG(Amount) from CarPricings where PricingID = (select PricingID from Pricings where Name = 'Günlük')
            int id = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(w => w.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(w => w.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(w => w.Amount);
            return value;
        }
        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Eketrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDisel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
