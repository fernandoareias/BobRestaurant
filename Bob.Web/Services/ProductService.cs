using Bob.Web.Models;
using Bob.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bob.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        public IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        } 

        public async Task<T> CreateProductsAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductApiBase + "api/v1/products",
                AccessToken = token
            }); 
        }

        public async Task<T> DeleteProductsAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.DELETE,
                Url = SD.ProductApiBase + "/api/v1/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/v1/products",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/v1/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductApiBase + "/api/v1/products",
                AccessToken = token
            });
        }
    }
}
