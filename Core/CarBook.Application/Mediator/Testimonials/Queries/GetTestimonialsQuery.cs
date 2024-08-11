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

public class GetTestimonialsQuery : IRequest<List<GetTestimonialsQueryResult>>
{
    public class GetTestimonialsQueryHandler : IRequestHandler<GetTestimonialsQuery, List<GetTestimonialsQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;
        IMapper _mapper;

        public GetTestimonialsQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTestimonialsQueryResult>> Handle(GetTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetTestimonialsQueryResult>>(values);
            return mappedvalues;
        }
    }
}
