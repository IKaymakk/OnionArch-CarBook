using CarBook.Application.Inferfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.TagClouds.Commands;

public class AddTagCloudToBlogCommand : IRequest
{
    public int BlogId { get; set; }
    public int TagCloudId { get; set; }

    public class AddTagCloudToBlogCommandHandler : IRequestHandler<AddTagCloudToBlogCommand>
    {
        private readonly IBlogRepository _blogRepository;

        public AddTagCloudToBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task Handle(AddTagCloudToBlogCommand request, CancellationToken cancellationToken)
        {
            await _blogRepository.AddTagCloudToBlogAsync(request.BlogId, request.TagCloudId);

        }
    }
}
