using CommentService.Models;

namespace CommentService.Services.IServices
{
    public interface IComment
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment> GetComment(Guid Id);
        Task<string> AddComment(Comment comment);
        Task<string> UpdateComment();
        Task<string> DeleteComment(Comment comment);
    }
}
