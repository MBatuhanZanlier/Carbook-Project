﻿using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    { 
        private readonly IRepository<Reservation> _reservationRepository;

        public CreateReservationCommandHandler(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationRepository.CreateAsync(new Reservation
            {
                Age = request.Age,
                CarID = request.CarID,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                DropOffLocationID = request.DropOffLocationID,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
                Surname = request.Surname,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
