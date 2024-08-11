using AutoMapper;
using CarBook.Application.Mediator.Features.Commands;
using CarBook.Application.Mediator.Features.Results;
using CarBook.Application.Mediator.FooterAddress.Commands;
using CarBook.Application.Mediator.FooterAddress.Results;
using CarBook.Application.Mediator.Locations.Commands;
using CarBook.Application.Mediator.Locations.Queries;
using CarBook.Application.Mediator.Locations.Results;
using CarBook.Application.Mediator.Pricings.Commands;
using CarBook.Application.Mediator.Pricings.Results;
using CarBook.Application.Mediator.Services.Commands;
using CarBook.Application.Mediator.Services.Results;
using CarBook.Application.Mediator.SocialMedias.Commands;
using CarBook.Application.Mediator.SocialMedias.Results;
using CarBook.Application.Mediator.Testimonials.Commands;
using CarBook.Application.Mediator.Testimonials.Results;
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

            CreateMap<FooterAddresses, GetFooterAddressQueryResult>().ReverseMap();
            CreateMap<FooterAddresses, GetFooterAddressByIdQueryResult>().ReverseMap();
            CreateMap<FooterAddresses, CreateFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddresses, RemoveFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddresses, UpdateFooterAddressCommand>().ReverseMap();

            CreateMap<Location, GetLocationsQueryResult>().ReverseMap();
            CreateMap<Location, GetLocationByIdQueryResult>().ReverseMap();
            CreateMap<Location, CreateLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateLocationCommand>().ReverseMap();
            CreateMap<Location, RemoveLocationCommand>().ReverseMap();

            CreateMap<Pricing, GetPricingQueryResult>().ReverseMap();
            CreateMap<Pricing, GetPricingByIdQueryResult>().ReverseMap();
            CreateMap<Pricing, CreatePricingCommand>().ReverseMap();
            CreateMap<Pricing, UpdatePricingCommand>().ReverseMap();
            CreateMap<Pricing, RemovePricingCommand>().ReverseMap();

            CreateMap<Service, GetServicesQueryResult>().ReverseMap();
            CreateMap<Service, GetServiceByIdQueryResult>().ReverseMap();
            CreateMap<Service, CreateServiceCommand>().ReverseMap();
            CreateMap<Service, UpdateServiceCommand>().ReverseMap();
            CreateMap<Service, RemoveServiceCommand>().ReverseMap();

            CreateMap<SocialMedia, GetSocialMediasQueryResult>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaByIdQueryResult>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, RemoveSocialMediaCommand>().ReverseMap();

            CreateMap<Testimonial, GetTestimonialsQueryResult>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, RemoveTestimonialCommand>().ReverseMap();
        }
    }
}
