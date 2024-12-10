using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        int GetCarCountByTranmissionIsAuto();
        string GetBrandNameByMaxChar();
        string GetBlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThen1000();
        int GetCarCountByFuelGasolineOrDisel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceMax();
        string GetCarBrandAndModelByRentPriceMin();
    }
}
