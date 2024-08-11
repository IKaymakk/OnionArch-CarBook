using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Testimonials.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Testimonials.Queries;

public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
{
    public int id { get; set; }

    public GetTestimonialByIdQuery(int id)
    {
        this.id = id;
    }

    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        IRepository<Testimonial> _repository;
        IMapper _mapper;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.id);
            var mappedvalue = _mapper.Map<GetTestimonialByIdQueryResult>(value);
            return mappedvalue;
        }
    }
}