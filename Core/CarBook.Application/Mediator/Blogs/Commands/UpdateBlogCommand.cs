using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Commands;

public class UpdateBlogCommand : IRequest
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string? CoverImageUrl { get; set; }
    public string MainImage { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }

    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        IMapper _mapper;

        public UpdateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);
        }
    }
}
