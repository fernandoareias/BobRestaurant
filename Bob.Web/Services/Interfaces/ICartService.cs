using Bob.Web.Models;
using System.Threading.Tasks;

namespace Bob.Web.Services.Interfaces
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);
        Task<T> AddToCartAsync<T>(CartDto cart, string token = null);
        Task<T> UpdateCartAsync<T>(CartDto cart, string token = null);
        Task<T> RemoveCartAsync<T>(int cartId, string token = null);
        Task<T> ApplyCoupon<T>(CartDto cartDto, string token = null);
        Task<T> RemoveCoupon<T>(string userId, string token = null);

        Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null);
    }
}
