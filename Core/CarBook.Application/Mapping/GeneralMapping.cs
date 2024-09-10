using AutoMapper;
using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Mediator.Authors.Commands;
using CarBook.Application.Mediator.Authors.Results;
using CarBook.Application.Mediator.Blogs.Commands;
using CarBook.Application.Mediator.Blogs.Results;
using CarBook.Application.Mediator.CarFeatures.Commands;
using CarBook.Application.Mediator.CarFeatures.Results;
using CarBook.Application.Mediator.CarPricings.Results;
using CarBook.Application.Mediator.Cars.Results;
using CarBook.Application.Mediator.Comment.Commands;
using CarBook.Application.Mediator.Comment.Results;
using CarBook.Application.Mediator.Contacts.Commands;
using CarBook.Application.Mediator.Contacts.Results;
using CarBook.Application.Mediator.Features.Commands;
using CarBook.Application.Mediator.Features.Results;
using CarBook.Application.Mediator.FooterAddress.Commands;
using CarBook.Application.Mediator.FooterAddress.Results;
using CarBook.Application.Mediator.Locations.Commands;
using CarBook.Application.Mediator.Locations.Queries;
using CarBook.Application.Mediator.Locations.Results;
using CarBook.Application.Mediator.Pricings.Commands;
using CarBook.Application.Mediator.Pricings.Results;
using CarBook.Application.Mediator.Reservations.Commands;
using CarBook.Application.Mediator.Services.Commands;
using CarBook.Application.Mediator.Services.Results;
using CarBook.Application.Mediator.SocialMedias.Commands;
using CarBook.Application.Mediator.SocialMedias.Results;
using CarBook.Application.Mediator.TagClouds.Results;
using CarBook.Application.Mediator.Testimonials.Commands;
using CarBook.Application.Mediator.Testimonials.Results;
using CarBook.Domain.Entities;
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
            CreateMap<Car, GetLast5CarsWithBrandQueryResult>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();

            CreateMap<Comments, CommentListQueryResult>().ReverseMap();
            CreateMap<Comments, CreateCommentCommand>().ReverseMap();

            CreateMap<CarFeature, GetCarFeatureByCarIdQueryResult>().
                ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
                .ReverseMap();
            CreateMap<CarFeature, CreateCarFeatureByCarCommand>().ReverseMap();



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

            CreateMap<Contact, GetContactsQueryResult>().ReverseMap();
            CreateMap<Contact, GetContactByIdQueryResult>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact, RemoveContactCommand>().ReverseMap();

            CreateMap<Author, GetAuthorsQueryResult>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryResult>().ReverseMap();
            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, RemoveAuthorCommand>().ReverseMap();

            CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
            CreateMap<Blog, GetBlogsByIdQueryResult>()
           .ForMember(dest => dest.TagClouds, opt => opt.MapFrom(src => src.BlogTagClouds)).ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogsAuthorDetailsResult>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
            CreateMap<Blog, RemoveBlogCommand>().ReverseMap();
            CreateMap<Blog, GetLast3BlogsWithAuthorsQueryResult>().ReverseMap();
            CreateMap<Blog, GetBlogsWithAuthorsQueryResult>().ReverseMap();
            CreateMap<Blog, GetBlogWithTagCloudQueryResult>().ReverseMap();
            CreateMap<BlogTagCloud, TagCloudDto>()
           .ForMember(dest => dest.TagCloudId, opt => opt.MapFrom(src => src.TagCloudId))
           .ForMember(dest => dest.TagCloudTitle, opt => opt.MapFrom(src => src.TagClouds));

            CreateMap<TagCloud, TagCloudWithBlogsQueryResult>()
            .ForMember(dest => dest.BlogTitles, opt => opt.MapFrom(src => src.BlogTagClouds.Select(btc => btc.Blogs.Title).ToList()));

            CreateMap<CarPricing, GetCarsWithPricingsQueryResult>()
                .ForMember(x => x.BrandName, y => y.MapFrom(x => x.Car.Brand.Name)).ReverseMap();

            CreateMap<Rezervasyon, CreateReservationCommand>().ReverseMap();
        }
    }
}
