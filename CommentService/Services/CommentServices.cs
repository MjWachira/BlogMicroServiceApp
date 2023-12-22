using CommentService.Data;
using CommentService.Models;
using CommentService.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Services
{
    public class CommentServices : IComment
    {
        private readonly ApplicationDbContext _context;
        public CommentServices( ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddComment(Comment comment)
        {
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
            return "Comment Added Successfully";
        }

        public async Task<string> DeleteComment(Comment comment)
        {
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return "Comment Deleted Successfully";
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment> GetComment(Guid Id)
        {
            return await _context.Comment.Where(b => b.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateComment()
        {
            await _context.SaveChangesAsync();
            return "Comment Updated Successsfully";
        }
    }
}
