using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal AvgRentPriceForDaily { get; set; }
        public decimal AvgRentPriceForWeekly { get; set; }
        public decimal AvgRentPriceForMonthly { get; set; }
        public int CarCountByTranmissionIsAuto { get; set; }
        public string BrandNameByMaxChar { get; set; }
        public string BlogTitleByMaxBlogComment { get; set; }
        public int CarCountByKmSmallerThen1000 { get; set; }
        public int CarCountByFuelGasolineOrDisel { get; set; }
        public int CarCountByFuelElectric { get; set; }
        public string GetCarBrandAndModelByRentPriceMax { get; set; }
        public string GetCarBrandAndModelByRentPriceMin { get; set; }

    }
}
