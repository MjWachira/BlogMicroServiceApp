using AutoMapper;
using CommentService.Models;
using CommentService.Models.Dtos;

namespace CommentService.Profiles
{
    public class CommentsProfile:Profile
    {
        public CommentsProfile()
        {
            CreateMap<AddCommentDto, Comment>().ReverseMap();   
        }
    }
}

