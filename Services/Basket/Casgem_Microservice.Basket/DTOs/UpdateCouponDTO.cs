namespace Casgem_Microservice.Basket.DTOs
{
    public class UpdateCouponDTO
    {
        public int CouponId { get; set; }
        public int Rate { get; set; }
        public string DiscountCode { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
