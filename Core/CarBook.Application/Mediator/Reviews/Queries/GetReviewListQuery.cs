using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Reviews.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Reviews.Queries
{
    public class GetReviewListQuery:IRequest<List<GetReviewListResult>>
    {
        public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, List<GetReviewListResult>>
        {
            private readonly IRepository<Review> _repoitory;
            IMapper _mapper;
            public GetReviewListQueryHandler(IRepository<Review> repository,IMapper mapper)
            {
                _mapper = mapper;
                _repoitory = repository;
            }
            public async Task<List<GetReviewListResult>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
            {
                var values = await _repoitory.GetAllAsync();
                var mappedvalues = _mapper.Map<List<GetReviewListResult>>(values);
                return mappedvalues;
            }
        }
    }
}
