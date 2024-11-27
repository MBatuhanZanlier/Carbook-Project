using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        } 
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {

                BrandId = command.BrandId,
                CoverImage = command.CoverImage,
                Seat = command.Seat,
                Luggage = command.Luggage,
                Km = command.Km,
                Model = command.Model,
                Transmission = command.Transmission,
                Fuel = command.Fuel, 
                BigImageUrl = command.BigImageUrl,

            });
        }
    }
}
