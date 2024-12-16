using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            #region Statistic1
            var responseMessage1 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                int carcountrandom = random.Next(0, 101);
                var jsonData1=await responseMessage1.Content.ReadAsStringAsync();
                var value1 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData1);
                ViewBag.carcount = value1.CarCount;
                ViewBag.carcountrandom = carcountrandom;
            }
            #endregion

            #region Statistic2
            var responseMessage2 = await client.GetAsync("https://localhost:7100/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int LocationRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationcount = value2.LocationCount;
                ViewBag.LocationRandom = LocationRandom;
            }
            #endregion

            #region Statistic3
            var responseMessage3 = await client.GetAsync("https://localhost:7100/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int Authorcountrandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var value3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.Authorcount = value3.AuthorCount;
                ViewBag.Authorcountrandom = Authorcountrandom;
            }
            #endregion

            #region Statistic4
            var responseMessage4 = await client.GetAsync("https://localhost:7100/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int Blogcountrandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var value4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.Blogcount = value4.BlogCount;
                ViewBag.Blogcountrandom = Blogcountrandom;
            }
            #endregion

            #region Statistic5
            var responseMessage5 = await client.GetAsync("https://localhost:7100/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int Brandcountrandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var value5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.Brandcount = value5.BrandCount;
                ViewBag.Brandcountrandom = Brandcountrandom;
            }
            #endregion

            #region Statistic6
            var responseMessage6 = await client.GetAsync("https://localhost:7100/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int AvgRentPriceForDailyrandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var value6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.AvgRentPriceForDaily = value6.AvgRentPriceForDaily.ToString("0.00");
                ViewBag.AvgRentPriceForDailyrandom = AvgRentPriceForDailyrandom;
            }
            #endregion

            #region Statistic7
            var responseMessage7 = await client.GetAsync("https://localhost:7100/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int AvgRentPriceForWeeklyrandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var value7 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
                ViewBag.AvgRentPriceForWeekly = value7.AvgRentPriceForWeekly.ToString("0.00");
                ViewBag.AvgRentPriceForWeeklyrandom = AvgRentPriceForWeeklyrandom;
            }
            #endregion

            #region Statistic8
            var responseMessage8 = await client.GetAsync("https://localhost:7100/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int AvgRentPriceForMonthlyrandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var value8 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
                ViewBag.AvgRentPriceForMonthly = value8.AvgRentPriceForMonthly.ToString("0.00");
                ViewBag.AvgRentPriceForMonthlyrandom = AvgRentPriceForMonthlyrandom;
            }
            #endregion

            #region Statistic9
            var responseMessage9 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int CarCountByTranmissionIsAutorandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var value9 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData9);
                ViewBag.CarCountByTranmissionIsAutor = value9.CarCountByTranmissionIsAuto;
                ViewBag.CarCountByTranmissionIsAutorandom = CarCountByTranmissionIsAutorandom;
            }
            #endregion

            #region Statistic10
            var responseMessage10 = await client.GetAsync("https://localhost:7100/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int BrandNameByMaxCarrandom = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var value10 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData10);
                ViewBag.BrandNameByMaxCar = value10.BrandNameByMaxCar;
                ViewBag.BrandNameByMaxCarrandom = BrandNameByMaxCarrandom;
            }
            #endregion

            #region Statistic11
            var responseMessage11 = await client.GetAsync("https://localhost:7100/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int BlogTitleByMaxBlogCommentrandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var value11 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData11);
                ViewBag.BlogTitleByMaxBlogComment = value11.BlogTitleByMaxBlogComment;
                ViewBag.BlogTitleByMaxBlogCommentrandom = BlogTitleByMaxBlogCommentrandom;
            }
            #endregion

            #region Statistic12
            var responseMessage12 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int CarCountByKmSmallerThen1000random = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var value12 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData12);
                ViewBag.CarCountByKmSmallerThen1000 = value12.CarCountByKmSmallerThen1000;
                ViewBag.CarCountByKmSmallerThen1000random = CarCountByKmSmallerThen1000random;
            }
            #endregion

            #region Statistic13
            var responseMessage13 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCountByFuelGasolineOrDisel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int CarCountByFuelGasolineOrDiselrandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var value13 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData13);
                ViewBag.CarCountByFuelGasolineOrDisel = value13.CarCountByFuelGasolineOrDisel;
                ViewBag.CarCountByFuelGasolineOrDiselrandom = CarCountByFuelGasolineOrDiselrandom;
            }
            #endregion

            #region Statistic14
            var responseMessage14 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int CarCountByFuelElectricrandom = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var value14 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData14);
                ViewBag.CarCountByFuelElectric = value14.CarCountByFuelElectric;
                ViewBag.CarCountByFuelElectricrandom = CarCountByFuelElectricrandom;
            }
            #endregion

            #region Statistic15
            var responseMessage15 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarBrandAndModelByRentPriceMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int CarBrandAndModelByRentPriceMaxrandom = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var value15 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData15);
                ViewBag.CarBrandAndModelByRentPriceMax = value15.CarBrandAndModelByRentPriceMax;
                ViewBag.CarBrandAndModelByRentPriceMaxrandom = CarBrandAndModelByRentPriceMaxrandom;
            }
            #endregion

            #region Statistic16
            var responseMessage16 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarBrandAndModelByRentPriceMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int CarBrandAndModelByRentPriceMinrandom = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var value16 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData16);
                ViewBag.CarBrandAndModelByRentPriceMin = value16.CarBrandAndModelByRentPriceMin;
                ViewBag.CarBrandAndModelByRentPriceMinrandom = CarBrandAndModelByRentPriceMinrandom;
            }
            #endregion
            return View();
        }
    }
}
