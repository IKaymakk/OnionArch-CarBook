using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarPricings.Commands
{
    public class UpdateCarPricingCommand : IRequest
    {
        public PricingDtos PricingDto { get; set; }

        public class PricingDtos
        {
            public int CarId { get; set; }
            public decimal? DailyAmount { get; set; }
            public decimal? WeeklyAmount { get; set; }
            public decimal? MonthlyAmount { get; set; }
        }

        public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand>
        {
            private readonly IRepository<CarPricing> _repository;

            public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
            {
                var carPricings = await _repository.GetAllWithIncludesAsync(
                    x => x.CarId == request.PricingDto.CarId,
                    x => x.Pricing, // İlişkili `Pricing` tablosunu dahil et
                    x => x.Car       // İlişkili `Car` tablosunu dahil et
                );

                if (carPricings != null && carPricings.Any())
                {
                    foreach (var carPricing in carPricings)
                    {
                        if (carPricing.Pricing.Name == "Günlük" && request.PricingDto.DailyAmount.HasValue)
                        {
                            carPricing.Amount = request.PricingDto.DailyAmount.Value;
                        }
                        else if (carPricing.Pricing.Name == "Haftalık" && request.PricingDto.WeeklyAmount.HasValue)
                        {
                            carPricing.Amount = request.PricingDto.WeeklyAmount.Value;
                        }
                        else if (carPricing.Pricing.Name == "Aylık" && request.PricingDto.MonthlyAmount.HasValue)
                        {
                            carPricing.Amount = request.PricingDto.MonthlyAmount.Value;
                        }
                    }

                    await _repository.UpdateRangeAsync(carPricings);
                }
            }



        }
    }
}