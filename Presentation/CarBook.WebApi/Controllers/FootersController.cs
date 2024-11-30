using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FootersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet] 
        public async Task<IActionResult> ListFooter()
        {
            var values = await _mediator.Send(new GetFooterQuery()); 
            return Ok(values);  

        }
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetFooter(int id)
        {
            var values=await _mediator.Send(new GetFooterByIdQuery(id)); 
            return Ok(values);
        }
        [HttpDelete] 
        public async Task<IActionResult> RemoveFooter(int id)
        {
           await _mediator.Send(new RemoveFooterCommand(id));
            return Ok("Başarıyla Silindi");
        }
        [HttpPost] 
        public async Task<IActionResult> CreateFooter(CreateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Oluştu");
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }
        
    }
}
