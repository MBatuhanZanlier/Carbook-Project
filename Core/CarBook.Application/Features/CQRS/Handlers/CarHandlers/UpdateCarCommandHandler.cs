using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        } 
        public async Task Handle(UpdateCarCommand command)
        {
            var values=await _repository.GetByıdAsync(command.CarId); 
            values.Fuel=command.Fuel; 
            values.Transmission=command.Transmission; 
            values.BrandId=command.BrandId; 
            values.CoverImage=command.CoverImage; 
            values.Km=command.Km; 
            values.Seat=command.Seat;  
            values.Model=command.Model; 
            values.Luggage=command.Luggage;  
            values.BigImageUrl=command.BigImageUrl;
            await _repository.UpdateAsync(values);

        }

    }
}
