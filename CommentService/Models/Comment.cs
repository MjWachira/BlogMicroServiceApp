namespace CommentService.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string userId { get; set; } = string.Empty;

        public string PostId { get; set; } = string.Empty;

        public string CommentDescription { get; set; } = string.Empty;
        
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
