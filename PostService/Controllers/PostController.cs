using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Models;
using PostService.Models.Dtos;
using PostService.Services.IServices;

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _postservice;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public PostController( IPost post, IMapper mapper)
        {
            _mapper = mapper;
            _postservice = post;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllPosts()
        {
            var posts = await _postservice.GetAllPosts();
            _response.Result = posts;
            return Ok(_response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> AddPost(AddPostDto addPostDto)
        {
            var post = _mapper.Map<Post>(addPostDto);
            var response = await _postservice.AddPost(post);
            _response.Result = response;
            return Created("",_response);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<ResponseDto>> GetPost(Guid Id)
        {
            var post = await _postservice.GetPost(Id);
            if (post == null)
            {
                _response.Errormessage = "post not found";
                return NotFound(_response);
            }
            _response.Result = post;
            return Ok(_response);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ResponseDto>> UpdatePost(Guid Id, AddPostDto UPost)
        {
            var post = await _postservice.GetPost(Id);
            if (post == null)
            {
                _response.Errormessage = "post not found";
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _mapper.Map(UPost, post);
            var res = await _postservice.UpdatePost();
            _response.Result = res;
            return Ok(_response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<ResponseDto>>DeletePost(Guid Id)
        {
            var post = await _postservice.GetPost(Id);
            if (post == null)
            {
                _response.Errormessage = "post not found";
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            var res = await _postservice.DeletePost(post);
            _response.Result = res;
            return Ok(_response);
        }

    }
    
}
