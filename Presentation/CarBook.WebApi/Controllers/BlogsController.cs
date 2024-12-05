using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListBlog()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Oluştu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("GetLast3BlogWithAuthors")] 
        public async Task<IActionResult> GetLast3BlogWithAuthors()
        {
            var values=await _mediator.Send(new GetLast3BlogWithAuthorsQuery());
            return Ok(values);
        }    
        [HttpGet("GetAllBlogsWithAuthor")] 
        public async Task<IActionResult> GetAllBlogsWithAuthor()
        {
            var values=await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        } 
        [HttpGet("GetAllBlogWithAuthorsTake3")] 
        public async Task<IActionResult> GetAllBlogWithAuthorsTake3(int id)
        {
            var values=await _mediator.Send(new GetByIdWithAuthorTake3Query(id));
            return Ok(values);
        } 
        [HttpGet("GetBlogByAutorId")] 
        public async Task<IActionResult> GetBlogByAutorId(int id)
        {
            var values=await _mediator.Send(new GetBlogByAutorIdQuery(id));
            return Ok(values);
        }
    }
}
