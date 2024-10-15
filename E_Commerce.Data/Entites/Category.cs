namespace E_Commerce.Data.Entites
{
    public class Category
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? TotalProducts { get; set; } = 0;
        public ICollection<Product>? Products { get; set; }
    }
}
