using CarBook.Application.Mediator.Reviews.Commands;
using CarBook.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName)
                .MinimumLength(5).WithMessage("Lütfen Adınızı Giriniz")
                .MaximumLength(50).WithMessage("Karakter Sınırını Aştınız")
                .Must(x => !x.Any(char.IsDigit)).WithMessage("İsim yalnızca harflerden oluşmalıdır");

            RuleFor(x => x.Comment)
               .MinimumLength(25).WithMessage("En Az 25 Karakter Giriniz")
               .MaximumLength(500).WithMessage("Karakter Sınırını Aştınız");

            RuleFor(x => x.CustomerImage)
                .NotEmpty().WithMessage("Boş Bırakılamaz")
            .MaximumLength(1000).WithMessage("Karakter Sınırını Aştınız");

        }
    }
}
