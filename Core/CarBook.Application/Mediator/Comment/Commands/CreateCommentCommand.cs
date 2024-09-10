using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Comment.Commands;

public class CreateCommentCommand : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int BlogId { get; set; }
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comments> _repository;
        IMapper _mapper;

        public CreateCommentCommandHandler(IRepository<Comments> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var mappedvalues = _mapper.Map<Comments>(request);
            mappedvalues.CreatedDate = DateTime.Now;
            await _repository.CreateAsync(mappedvalues);
        }
    }
}
