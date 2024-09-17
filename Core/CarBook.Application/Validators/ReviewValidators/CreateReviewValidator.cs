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
           

          
        }
    }
}
