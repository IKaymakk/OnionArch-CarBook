using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.CarFeatures.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarFeatures.Queries;

public class GetCarFeatureByCarIdQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
{
    public int id { get; set; }

    public GetCarFeatureByCarIdQuery(int id)
    {
        this.id = id;
    }
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        private readonly IMapper _mapper;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarFeaturesWithCarAndFeature(request.id);
            var mappedvalues = _mapper.Map<List<GetCarFeatureByCarIdQueryResult>>(values);
            return mappedvalues;
            //return values.Select(x => new GetCarFeatureByCarIdQueryResult
            //{
            //    CarId = x.CarId,
            //    Avaible = x.Avaible,
            //    CarFeatureId = x.CarFeatureId,
            //    CarModel = x.Car.Model,
            //    FeatureId = x.CarFeatureId,
            //    FeatureName = x.Feature.Name,
            //    BrandName = x.Car.Brand.Name
            //}).ToList();
        }
    }
}
