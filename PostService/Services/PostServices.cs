using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.Models;
using PostService.Services.IServices;

namespace PostService.Services
{
    public class PostServices : IPost
    {

        private readonly ApplicationDbContext _context;
        public PostServices(ApplicationDbContext context)
        {
            _context = context;   
        }
        public async Task<string> AddPost(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();
            return "Post Created Successfully";
        }

        public async Task<string> DeletePost(Post post)
        {
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return "Post Deleted Successfully";
        }

        public async Task<List<Post>> GetAllPosts()
        {
           return await _context.Post.ToListAsync();
        }

        public async Task<Post> GetPost(Guid Id)
        {
            return await _context.Post.Where(b=>b.Id == Id).FirstOrDefaultAsync();   
        }

        public async Task<string> UpdatePost()
        {
            await _context.SaveChangesAsync();
            return "Post Updated Successsfully";

        }
        

    }
}
