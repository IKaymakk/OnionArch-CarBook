using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Reviews.Commands
{
    public class CreateReviewCommand : IRequest
    {
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RatingValue { get; set; }
        public DateTime ReviewDate { get; set; }

        public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
        {
            private readonly IRepository<Review> _repository;
            IMapper _mapper;

            public CreateReviewCommandHandler(IMapper mapper, IRepository<Review> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
            {
                var values = _mapper.Map<Review>(request);
                await _repository.CreateAsync(values);
            }
        }
    }
}
