namespace Casgem_Microservice.Catalog.DTOs.ProductDTOs
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}
