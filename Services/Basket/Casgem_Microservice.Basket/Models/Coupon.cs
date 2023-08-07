namespace Casgem_Microservice.Basket.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public int Rate { get; set; }
        public string DiscountCode { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
