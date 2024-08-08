namespace GenericRepositoryPattern.Models
{
    public class AuthorModel : BaseEntity
    {
        public string authorName { get; set; }
        public int authorage { get; set; }
        public string authorAddress { get; set; }
    }
}
