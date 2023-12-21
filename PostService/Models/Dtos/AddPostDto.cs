namespace PostService.Models.Dtos
{
    public class AddPostDto
    {
        public string userId { get; set; } = string.Empty;
        public string PostName { get; set; } = string.Empty;

        public string PostDescription { get; set; } = string.Empty;

        public string PostImage { get; set; } = string.Empty;

    }
}
