namespace OrderSolution.API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
