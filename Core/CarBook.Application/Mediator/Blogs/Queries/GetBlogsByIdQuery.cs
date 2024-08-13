using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Blogs.Results;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Mediator.Blogs.Queries;

public class GetBlogsByIdQuery : IRequest<GetBlogsByIdQueryResult>
{
    public int id { get; set; }
    public GetBlogsByIdQuery(int id)
    {
        this.id = id;
    }


    public class GetBlogsByIdQueryHandler : IRequestHandler<GetBlogsByIdQuery, GetBlogsByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;
        IMapper _mapper;

        public GetBlogsByIdQueryHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBlogsByIdQueryResult> Handle(GetBlogsByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.id);
            var mappedvalues = _mapper.Map<GetBlogsByIdQueryResult>(values);
            return mappedvalues;
        }
    }
}
