using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
           var values= await _mediator.Send(new GetCarFeatureByCarIdQuery(id));    
            return Ok(values);
        }
        [HttpGet("ChangeCarFeatureAvailableToTrue")] 
        public async Task<IActionResult> ChangeCarFeatureAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaibleChangeToTrueCommand(id)); 
            return Ok("Güncelleme Yapıldı");
        }  
        [HttpGet("ChangeCarFeatureAvailableToFalse")] 
        public async Task<IActionResult> ChangeCarFeatureAvailableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaibleChangeToFalseCommand(id)); 
            return Ok("Güncelleme Yapıldı");
        }

        [HttpPost] 
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme Yapıldı");
        }
    }
}
