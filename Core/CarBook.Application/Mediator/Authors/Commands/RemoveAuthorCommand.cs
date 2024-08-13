using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Authors.Commands
{
    public class RemoveAuthorCommand : IRequest
    {
        public int AuthorId { get; set; }
        public RemoveAuthorCommand(int authorId)
        {
            AuthorId = authorId;
        }


        public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
        {
            private readonly IRepository<Author> _repository;

            public RemoveAuthorCommandHandler(IRepository<Author> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.AuthorId);
                await _repository.RemoveAsync(value);
            }
        }
    }
}
