using CarBookApplication.Features.Mediator.Commands.AuthorCommands;
using CarBookApplication.Features.Mediator.Commands.BlogCommands;
using CarBookApplication.Features.Mediator.Queries.AuthorQueries;
using CarBookApplication.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("guncellendi");
        }
        [HttpGet("GetLast3BlogsWithAuthorList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorList()
        {
            var values = await _mediator.Send(new GetLast3BlogWithAuthorsQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBlogWithAuthorsList")]
        public async Task<IActionResult> GetAllBlogWithAuthorsList()
        {
            var values = await _mediator.Send(new GetAllBlogWithAuthorQuery());
            return Ok(values);
        }
    }
}
