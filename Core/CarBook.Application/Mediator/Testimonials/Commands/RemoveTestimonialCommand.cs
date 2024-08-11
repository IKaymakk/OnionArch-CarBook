using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Testimonials.Commands
{
    public class RemoveTestimonialCommand : IRequest
    {
        public int id { get; set; }

        public RemoveTestimonialCommand(int id)
        {
            this.id = id;
        }
        public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
        {
            private readonly IRepository<Testimonial> _repository;
            IMapper _mapper;

            public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.id);
                await _repository.RemoveAsync(value);
            }
        }
    }

}
