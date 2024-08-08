namespace GenericRepositoryPattern.Models
{
    public class BookModel : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Author { get; set; }
    }
}
