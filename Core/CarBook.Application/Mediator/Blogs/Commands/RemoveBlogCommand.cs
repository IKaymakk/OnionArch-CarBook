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
    public class RemoveBlogCommand : IRequest
    {
        public int id { get; set; }

        public RemoveBlogCommand(int id)
        {
            this.id = id;
        }

        public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
        {
            private readonly IRepository<Blog> _repository;

            public RemoveBlogCommandHandler(IRepository<Blog> repository) 
            {
                _repository = repository;
            }
            public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.id);
                await _repository.RemoveAsync(value);
            }
        }
    }
}
