namespace TechLibrary.API.Entities
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public int Amount { get; set; }
    }
}
