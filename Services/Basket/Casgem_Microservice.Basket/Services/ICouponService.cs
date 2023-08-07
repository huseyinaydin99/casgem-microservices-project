using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Basket.DTOs;
using Casgem_Microservice.Basket.Models;

namespace Casgem_Microservice.Basket.Services
{
    public interface ICouponService
    {
        Task<Response<List<ResultCouponDTO>>> GetCouponList();
        Task<Response<NoContent>> CreateCoupon(CreateCouponDTO createCouponDTO);
        Task<Response<NoContent>> UpdateCoupon(UpdateCouponDTO updateCouponDTO);
        Task<Response<NoContent>> DeleteCoupon(int couponId);
        Task<Response<ResultCouponDTO>> GetCouponById(int couponId);
    }
}
