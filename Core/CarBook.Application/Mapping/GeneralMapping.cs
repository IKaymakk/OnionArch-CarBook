using AutoMapper;
using CarBook.Application.Mediator.Features.Commands;
using CarBook.Application.Mediator.Features.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, GetFeatureQueryResult>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdQueryResult>().ReverseMap();
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateFeatureCommand>().ReverseMap();
            CreateMap<Feature, RemoveFeatureCommand>().ReverseMap();

        }
    }
}
