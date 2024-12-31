using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            #region Statistic1
            var responseMessage1 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                int carcountrandom = random.Next(0, 101);
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
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
            return View();
        }
    }
}
