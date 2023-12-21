using PostService.Models;
using static Azure.Core.HttpHeader;

namespace PostService.Services.IServices
{
    public interface IPost
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPost(Guid Id);
        Task<string> AddPost(Post post);
        Task<string> UpdatePost();
        Task<string> DeletePost(Post post);
    }
}
