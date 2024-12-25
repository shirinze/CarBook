using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region Statistic1
            var responseMessage1 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var value1 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData1);
                ViewBag.Carcount = value1.CarCount;
                
            }
            #endregion

            #region Statistic2
            var responseMessage2 = await client.GetAsync("https://localhost:7100/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationcount = value2.LocationCount;
            }
            #endregion

            #region Statistic3
            var responseMessage3 = await client.GetAsync("https://localhost:7100/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var value3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.Brandcount = value3.BrandCount;
            }
            #endregion

            #region Statistic4
            var responseMessage4 = await client.GetAsync("https://localhost:7100/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var value4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.CarCountByFuelElectric = value4.CarCountByFuelElectric;
            }
            #endregion
            return View();
        }
    }
}
