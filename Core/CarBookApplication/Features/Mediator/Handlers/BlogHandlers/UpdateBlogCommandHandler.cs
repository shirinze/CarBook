using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.BlogCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.BlogID);
            value.AuthorID=request.AuthorID;
            value.CategoryID = request.CategoryID;
            value.CreatedDate=request.CreatedDate;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
