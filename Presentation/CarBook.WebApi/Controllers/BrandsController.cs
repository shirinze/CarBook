using CarBookApplication.Features.CQRS.Commands.BrandCommands;
using CarBookApplication.Features.CQRS.Handlers.BrandHandlers;
using CarBookApplication.Features.CQRS.Queries.BrandQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly UpdateBrandCmmandHandler _updateBrandCmmandHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCmmandHandler updateBrandCmmandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _updateBrandCmmandHandler = updateBrandCmmandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var value =await _getBrandQueryHandler.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value=await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
           await _createBrandCommandHandler.Handle(command);
            return Ok("brand eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("brand silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCmmandHandler.Handle(command);
            return Ok("brand guncellendi");
        }
    }
}
