using CarBook.Dto.BlogDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarFeatureDeatilDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarDetails")]
    public class AdminCarFeatureDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/CarFeatures?id=" + id);
            List<ResultCarFeatureDetailDto> carFeatures = new List<ResultCarFeatureDetailDto>();
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                carFeatures = JsonConvert.DeserializeObject<List<ResultCarFeatureDetailDto>>(jsonData);
                if(carFeatures==null || carFeatures.Count == 0)
                {
                    carFeatures = new List<ResultCarFeatureDetailDto>
                    {
                        new ResultCarFeatureDetailDto{FeatureName="Audio",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Wifi",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Şarj Kablosu",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Hava Yastığı",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Bebek Koltuğu",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Gps",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Müzik",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Uyuma Yatagı",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Bluetooth",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Bilgisayar Destegi",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Çocuk Emniyet Kilidi",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Klima",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Start Stop",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Otomatik Ayna Kapatma",Available=false},
                        new ResultCarFeatureDetailDto{FeatureName="Extra Bagaj",Available=false}
                    };
                }
                return View(carFeatures);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureDetailDto> carfeaturedetaildto)
        {
            var client = _httpClientFactory.CreateClient();
            foreach (var item in carfeaturedetaildto)
            {
                if (item.Available)
                {
                    await client.GetAsync("https://localhost:7100/api/CarFeatures/ChangeCarFeatureAvailableTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    await client.GetAsync("https://localhost:7100/api/CarFeatures/ChangeCarFeatureAvailableFalse?id=" + item.CarFeatureID);

                }
            }
            return RedirectToAction("Index", "AdminCar");

        }
        
    }
}
