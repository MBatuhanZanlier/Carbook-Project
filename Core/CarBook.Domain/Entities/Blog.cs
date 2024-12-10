namespace CarBook.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; } 
        public List<TagCloud> TagClouds { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
