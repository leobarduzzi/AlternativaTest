
namespace AlternativaTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}