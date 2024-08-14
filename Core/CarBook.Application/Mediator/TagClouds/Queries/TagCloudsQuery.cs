using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.TagClouds.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.TagClouds.Queries;

public class TagCloudsQuery : IRequest<List<TagCloudsQueryResult>>
{
    public string TagCloudTitle { get; set; }


    public class TagCloudsQueryHanler : IRequestHandler<TagCloudsQuery, List<TagCloudsQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public TagCloudsQueryHanler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<TagCloudsQueryResult>> Handle(TagCloudsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new TagCloudsQueryResult
            {
                TagCloudTitle = x.TagCloudTitle
            }).ToList();

        }
    }
}
