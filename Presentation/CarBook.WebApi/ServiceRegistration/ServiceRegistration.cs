using CarBook.Application.Features.Handlers.AboutHandlers;
using CarBook.Application.Features.Handlers.BannerHandlers;
using CarBook.Application.Features.Handlers.BrandHandlers;
using CarBook.Application.Features.Handlers.CarHandlers;
using CarBook.Application.Features.Handlers.CategoryHandlers;
using CarBook.Application.Inferfaces;
using CarBook.Persistance.Repositories;
using Domain.Entities;
using Persistance.Context;

namespace CarBook.WebApi.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddApiApplicationServices(this IServiceCollection Services, IConfiguration configuration)
        {

            #region
            Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
            Services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            Services.AddScoped(typeof(IBrandRepository), typeof(BrandRepository));
            Services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));
            Services.AddScoped(typeof(IStatsRepository), typeof(StatsRepository));
            Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
            Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
            Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

            Services.AddScoped<GetAboutByIdQueryHandler>();
            Services.AddScoped<GetAboutQueryHandler>();
            Services.AddScoped<CreateAboutCommandHandler>();
            Services.AddScoped<RemoveAboutCommandHandler>();
            Services.AddScoped<UpdateAboutCommandHandler>();

            Services.AddScoped<GetBannerByIdQueryHandler>();
            Services.AddScoped<GetBannerQueryHandler>();
            Services.AddScoped<CreateBannerCommandHandler>();
            Services.AddScoped<RemoveBannerCommandHandler>();
            Services.AddScoped<UpdateBannerCommandHandler>();

            Services.AddScoped<GetBrandByIdQueryHandler>();
            Services.AddScoped<GetBrandQueryHandler>();
            Services.AddScoped<CreateBrandCommandHandler>();
            Services.AddScoped<RemoveBrandCommandHandler>();
            Services.AddScoped<UpdateBrandCommandHandler>();

            Services.AddScoped<GetCarByIdQueryHandler>();
            Services.AddScoped<GetCarWithBrandQueryHandler>();
            Services.AddScoped<GetCarQueryHandler>();
            Services.AddScoped<CreateCarCommandHandler>();
            Services.AddScoped<RemoveCarCommandHandler>();
            Services.AddScoped<UpdateCarCommandHandler>();

            Services.AddScoped<GetCategoryByIdQueryHandler>();
            Services.AddScoped<GetCategoryQueryHandler>();
            Services.AddScoped<CreateCategoryCommandHandler>();
            Services.AddScoped<RemoveCategoryCommandHandler>();
            Services.AddScoped<UpdateCategoryCommandHandler>();
            Services.AddScoped<GetCategoriesWithBlogCountsQueryHandler>();
            #endregion

            Services.AddScoped<CarBookContext>();

            Services.AddHttpClient();

            Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials(); // İsteğe bağlı: Çerezlerin paylaşılmasına izin verir
                });
            });
            Services.AddSignalR();


        }

    }
}
