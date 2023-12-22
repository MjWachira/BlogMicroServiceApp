using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Models;
using PostService.Models.Dtos;
using PostService.Services.IServices;
using System.Security.Claims;

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
        [Authorize]
        public async Task<ActionResult<ResponseDto>> AddPost(AddPostDto addPostDto)
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
           // var list = User.Claims.ToList();
            //var Id = list[1].Value;
            Console.WriteLine(Id);

            var post = _mapper.Map<Post>(addPostDto);

            post.userId = Id;

            var response = await _postservice.AddPost(post);
            
            _response.Result = response;
            return Created("",_response);
        }
        [HttpGet("All Posts for logedin user")]
        public async Task<ActionResult<ResponseDto>> GetUserPosts()
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var posts = await _postservice.GetUserPosts(Id);
            _response.Result = posts;
            return Ok(_response);
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
        [Authorize]
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
        [Authorize]
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
