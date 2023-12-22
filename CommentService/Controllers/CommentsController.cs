using AutoMapper;
using CommentService.Models;
using CommentService.Models.Dtos;
using CommentService.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CommentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IComment _commentservice;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public CommentsController(IComment comment, IMapper mapper)
        {
            _mapper = mapper;
            _commentservice = comment;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllComments()
        {
            var comments = await _commentservice.GetAllComments();
            _response.Result = comments;
            return Ok(_response);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> AddComment(AddCommentDto AddComment)
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var comment = _mapper.Map<Comment>(AddComment);
            comment.userId = Id;
            var response = await _commentservice.AddComment(comment);
            _response.Result = response;
            return Created("", _response);
        }

        [HttpGet("Id")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> GetComment(Guid Id)
        {
            var comment = await _commentservice.GetComment(Id);
            if (comment == null)
            {
                _response.Errormessage = "comment not found";
                return NotFound(_response);
            }
            _response.Result = comment;
            return Ok(_response);
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> UpdateComment(Guid Id, AddCommentDto UComment)
        {
            var comment = await _commentservice.GetComment(Id);
            if (comment == null)
            {
                _response.Errormessage = "comment not found";
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _mapper.Map(UComment, comment);
            var res = await _commentservice.UpdateComment();
            _response.Result = res;
            return Ok(_response);
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> DeleteComment(Guid Id)
        {
            var post = await _commentservice.GetComment(Id);
            if (post == null)
            {
                _response.Errormessage = "Comment not found";
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            var res = await _commentservice.DeleteComment(post);
            _response.Result = res;
            return Ok(_response);
        }
    }
}