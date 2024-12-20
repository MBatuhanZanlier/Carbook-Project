using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;
        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {

            _commentRepository.Create(comment);
            return Ok("Başarıyla Oluştu");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentRepository.GetById(id);
            _commentRepository.Remove(values);
            return Ok("Başarıyla Silindi");

        }
        [HttpGet("{id}")] 
        public IActionResult GetComment(int id)
        {
            var values=_commentRepository.GetById(id); 
            return Ok(values);
        }
        [HttpGet("CommentListByBlog")] 
        public IActionResult CommentListByBlog(int id)
        {
            var value = _commentRepository.GetCommentsByBlog(id); 
            return Ok(value);
        }
        [HttpGet("BlogForComentCount")] 
        public IActionResult BlogForComentCount(int id)
        {
            var values=_commentRepository.GetCountCommentByBlog(id);
            return Ok(values);
        }
        [HttpPost("AddComment")] 
        public async Task<IActionResult> AddComment(CreateCommentCommand command)
        {   
               await _mediator.Send(command);
            return Ok("Başarıyla Eklendi");
        }


    }
}
