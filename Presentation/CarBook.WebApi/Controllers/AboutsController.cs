using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    { 
        private readonly CreateAboutCommandHandler _createCommandHandler; 
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler; 
        private readonly UpdateAboutCommandHandler _updateAboutByIdQueryHandler; 
        private readonly GetAboutQueryHandler _getAboutQueryHandler; 
        private  readonly RemoveAboutCommandHandler _removeAboutByIdQueryHandler;

        public AboutsController(CreateAboutCommandHandler createCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, UpdateAboutCommandHandler updateAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, RemoveAboutCommandHandler removeAboutByIdQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _updateAboutByIdQueryHandler = updateAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _removeAboutByIdQueryHandler = removeAboutByIdQueryHandler;
        }


        [HttpGet] 
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle(); 
            return Ok(values);
        }
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id)); 
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createCommandHandler.Handle(command); 
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete] 
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutByIdQueryHandler.Handle(new RemoveAboutCommand(id)); 
            return Ok("Başarıyla Silindi");
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutByIdQueryHandler.Handle(command);
            return Ok("Başarıyla GüNCELLENDİ");
        }
    }
}
