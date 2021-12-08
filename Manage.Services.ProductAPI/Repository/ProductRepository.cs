using AutoMapper;
using Manage.Services.ProductAPI.Models;
using Manage.Services.ProductAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) return false;

            var remove = _context.Products.Remove(product);
            if (remove == null) return false;

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();


            return _mapper.Map<ProductDto>(product);

        }
    }
}
