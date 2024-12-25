using CarBook.Dto.CategoryDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Comments/CommentListByBlog?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(value);
            }
            return View();
        }
      
    }
}
