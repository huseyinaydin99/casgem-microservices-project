namespace Casgem_Microservice.Basket.DTOs
{
    public class CreateCouponDTO
    {
        public int Rate { get; set; }
        public string DiscountCode { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
