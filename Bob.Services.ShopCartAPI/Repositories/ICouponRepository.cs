using Bob.Services.ShopCartAPI.Models.DTOs;
using System.Threading.Tasks;

namespace Bob.Services.ShopCartAPI.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
