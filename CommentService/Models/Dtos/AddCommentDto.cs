namespace CommentService.Models.Dtos
{
    public class AddCommentDto
    {
        public string userId { get; set; } = string.Empty;

        public string PostId { get; set; } = string.Empty;

        public string CommentDescription { get; set; } = string.Empty;
    }
}
