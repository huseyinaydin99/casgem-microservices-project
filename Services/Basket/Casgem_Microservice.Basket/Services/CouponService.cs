using Casgem.MicroServices.Shared.DTOs;
using Casgem_Microservice.Basket.DTOs;
using Casgem_Microservice.Basket.Models;
using Dapper;
using Npgsql;
using System.Data;

namespace Casgem_Microservice.Basket.Services
{
    public class CouponService : ICouponService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public CouponService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL"));
        }

        public async Task<Response<NoContent>> CreateCoupon(CreateCouponDTO createCouponDTO)
        {
            var values = await _dbConnection.ExecuteAsync("INSERT INTO COUPONS(Rate, Code, CreatedTime) VALUES(@Rate, @Code, @CreatedTime);", createCouponDTO);
            if (values > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Ekleme sırasında hata oluştu.", 500);
        }

        public async Task<Response<NoContent>> DeleteCoupon(int couponId)
        {
            var values = await _dbConnection.ExecuteAsync("DELETE FROM COUPONS WHERE CouponId = @CouponId", new { Id = couponId });
            return values > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Silinecek ama kupon bulunamadı. Olmayan kuponu ben nasıl sileyim?", 404);
        }

        public async Task<Response<ResultCouponDTO>> GetCouponById(int couponId)
        {
            var values = (await _dbConnection.QueryAsync<ResultCouponDTO>("SELECT * FROM COUPONS WHERE CouponId = @CouponId")).FirstOrDefault();
            var dynamicParamter = new DynamicParameters();
            dynamicParamter.Add("@CouponId", couponId);
            return values == null ? Response<ResultCouponDTO>.Fail("Kupon bulunamadı", 404) : Response<ResultCouponDTO>.Success(values, 200);
        }

        public async Task<Response<List<ResultCouponDTO>>> GetCouponList()
        {
            var values = await _dbConnection.QueryAsync<ResultCouponDTO>("SELECT * FROM COUPONS");
            return Response<List<ResultCouponDTO>>.Success(values.ToList(), 200);
        }

        public async Task<Response<NoContent>> UpdateCoupon(UpdateCouponDTO updateCouponDTO)
        {
            var values = await _dbConnection.ExecuteAsync("UPDATE COUPONS SET Code=@Code, Rate=@Rate, CouponId=@CouponId WHERE CouponId = @CouponId;");
            var parameters = new DynamicParameters();
            parameters.Add("@Rate", updateCouponDTO.Rate);
            parameters.Add("@Code", updateCouponDTO.DiscountCode);
            parameters.Add("@CouponId", updateCouponDTO.CouponId);
            if (values > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Güncellenecek ama böyle bir kayıt yok. Olmayan kaydı nasıl güncelleyeyim?", 404);
        }
    }
}