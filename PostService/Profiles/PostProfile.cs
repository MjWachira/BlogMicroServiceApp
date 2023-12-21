using AutoMapper;
using PostService.Models;
using PostService.Models.Dtos;

namespace PostService.Profiles
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<AddPostDto, Post>().ReverseMap();
        }
    }
}
