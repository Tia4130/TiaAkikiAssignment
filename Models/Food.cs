//table: food //fields: id name price

namespace API1.Models
{
    public class Food
    {
        public int Id { get; set; }   // Primary Key
        public string Name { get; set; }
        public decimal Price { get; set; } 
    }
}
