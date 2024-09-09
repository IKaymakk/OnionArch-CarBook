using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Reservations.Commands;

public class CreateReservationCommand : IRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int PickUpLocationID { get; set; }
    public int DropOffLocationID { get; set; }
    public int CarId { get; set; }
    public int Age { get; set; }
    public int DriverLicenseYear { get; set; }
    public string? Description { get; set; }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Rezervasyon> _repository;
        IMapper _mapper;

        public CreateReservationCommandHandler(IRepository<Rezervasyon> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var mappedvalues = _mapper.Map<Rezervasyon>(request);
            mappedvalues.Status = "Rezervasyon Oluşturuldu";
            await _repository.CreateAsync(mappedvalues);


        }
    }
}
