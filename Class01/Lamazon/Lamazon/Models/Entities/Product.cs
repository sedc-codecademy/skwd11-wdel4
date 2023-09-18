using Lamazon.Models.Enums;

namespace Lamazon.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public CategoryEnum Category { get; set; }
        public ProductCategory Category { get; set; }
    }
}
