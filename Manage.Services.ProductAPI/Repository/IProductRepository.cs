using Manage.Services.ProductAPI.Models;
using Manage.Services.ProductAPI.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manage.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateProduct(ProductDto productDto);
        Task<ProductDto> UpdateProduct(ProductDto productDto);        
        Task<bool> DeleteProduct(int productId);


    }
}
