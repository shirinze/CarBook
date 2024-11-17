using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _Last3BlogWithAuthorComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _Last3BlogWithAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responesMessage = await client.GetAsync("https://localhost:7100/api/Blogs/GetLast3BlogsWithAuthorList");
            if (responesMessage.IsSuccessStatusCode)
            {
                var jsonData = await responesMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultLast3BlogWithAuthorDto>>(jsonData);
                return View(value);
            }

            return View();
        }
    
    }    
}

