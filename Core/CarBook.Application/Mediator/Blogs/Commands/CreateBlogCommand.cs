using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Commands
{
    public class CreateBlogCommand : IRequest
    {
        public string Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public string MainImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
        {
            private readonly IRepository<Blog> _repo;
            IMapper _mapper;

            public CreateBlogCommandHandler(IRepository<Blog> repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }
            public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                var values =  _mapper.Map<Blog>(request);
                await _repo.CreateAsync(values);
            }
        }
    }
}
