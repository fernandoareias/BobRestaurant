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
    }
}
