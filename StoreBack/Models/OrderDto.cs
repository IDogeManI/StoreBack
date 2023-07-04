using System.ComponentModel.DataAnnotations;

namespace StoreBack.Models
{
    public class OrderDto
    {
        [Key]
        public Guid Id { get; set; }
        public List<ProductDto> Products { get; set; } = null;
        public string Adress { get; set; } = null;
        public string OrderStatus { get; set; } = "Ok";

        public OrderDto()
        {
            Id = Guid.NewGuid();
        }
    }
}
