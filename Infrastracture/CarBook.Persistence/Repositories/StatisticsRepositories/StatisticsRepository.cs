using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.StatisticsInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            //select top(1) BlogId,COUNT(*) as 'yorumsayisi' from Comments group by BlogId order by yorumsayisi desc
            var values = _context.Comments.GroupBy(x => x.BlogId).Select(y => new
            {
                blogid = y.Key,
                count = y.Count()
            }).OrderByDescending(z => z.count).Take(1).FirstOrDefault();
            string blogtitle = _context.Blogs.Where(x => x.BlogID == values.blogid).Select(y => y.Title).FirstOrDefault();
            return blogtitle;
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandID).Select(y => new
            {
                brandID = y.Key,
                count = y.Count()
            }).OrderByDescending(z => z.count).Take(1).FirstOrDefault();
            string Brandname = _context.Brands.Where(x => x.BrandID == values.brandID).Select(y => y.Name).FirstOrDefault();
            return Brandname;

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
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Max(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string Brandmodel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return Brandmodel;
        }

        public string GetCarBrandAndModelByRentPriceMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Min(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string Brandmodel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return Brandmodel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
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
