using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responesMessage = await client.GetAsync("https://localhost:7100/api/Abouts");
            if (responesMessage.IsSuccessStatusCode)
            {
                var jsonData = await responesMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(value);
            }
            
            return View();
        }
    }
}
