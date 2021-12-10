using Bob.Services.CouponAPI.Models.DTOs;
using System.Threading.Tasks;

namespace Bob.Services.CouponAPI.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
