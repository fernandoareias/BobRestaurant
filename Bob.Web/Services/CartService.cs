using Bob.Web.Models;
using Bob.Web.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bob.Web.Services
{
    public class CartService : BaseService,ICartService
    {
        private readonly IHttpClientFactory _httpClient;
        public CartService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> AddToCartAsync<T>(CartDto cart, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = cart,
                Url = SD.ShoppingCartApiBase + "api/cart/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Data = null,
                Url = SD.ShoppingCartApiBase + $"api/cart/GetCart/{userId}",
                AccessToken = token
            });
        }

        public async Task<T> RemoveCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = cartId,
                Url = SD.ShoppingCartApiBase + $"api/cart/RemoveCart",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cart, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = cart,
                Url = SD.ShoppingCartApiBase + "api/cart/UpdateCart",
                AccessToken = token
            });
        }
    }
}
