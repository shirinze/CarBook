using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _Last3BlogWithAuthorComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _Last3BlogWithAuthorComponentPartial(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Blogs/GetLast3BlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultLast3BlogWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
