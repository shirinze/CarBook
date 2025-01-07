using CarBookApplication.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Validator.ReviewValidators
{
	public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
	{
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Boş geçilemez!");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("En az 5 karakter olmali");
            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Boş geçilemez!");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Boş geçilemez!");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("en az 50 karakter olamli");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("en fazla 500 karakter olamli");
        }
    }
}
