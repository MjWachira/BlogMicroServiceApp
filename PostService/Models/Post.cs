namespace PostService.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public string  userId { get; set; } = string.Empty;

        public string PostName { get; set; } = string.Empty;

        public string PostDescription { get; set; } = string.Empty;

        public string PostImage { get; set; } = string.Empty;

        public DateTime DatePosted { get; set; } = DateTime.Now;

    }
}
