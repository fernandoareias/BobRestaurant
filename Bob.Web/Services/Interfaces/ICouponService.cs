using System.Threading.Tasks;

namespace Bob.Web.Services.Interfaces
{
    public interface ICouponService
    {
        Task<T> GetCoupon<T>(string couponCode, string token = null);

    }
}
