namespace api.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string? AuthorName { get; set; }
        public List<string>? Categories { get; set; }
    }
}
