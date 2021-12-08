using Manage.Services.ProductAPI.Models.DTOs;
using Manage.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Services.ProductAPI.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        
        [HttpGet]
        [Authorize]
        public async Task<object> Get()
        {
            try
            {
                var products = await _productRepository.GetProducts();

                _response.Data = products;

                return _response;
            }
            catch (System.Exception ex)
            {

                _response.IsSucess = false;
                _response.Errors = new System.Collections.Generic.List<string>() { ex.ToString() };

                return _response;
            }
        }


        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);

                _response.Data = product;

                return _response;
            }
            catch (System.Exception ex)
            {

                _response.IsSucess = false;
                _response.Errors = new System.Collections.Generic.List<string>() { ex.ToString() };

                return _response;
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateProduct(productDto);

                _response.Data = model;

                return _response;
            }
            catch (System.Exception ex)
            {

                _response.IsSucess = false;
                _response.Errors = new System.Collections.Generic.List<string>() { ex.ToString() };

                return _response;
            }
        }


        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var product = await _productRepository.UpdateProduct(productDto);

                _response.Data = product;

                return _response;
            }
            catch (System.Exception ex)
            {

                _response.IsSucess = false;
                _response.Errors = new System.Collections.Generic.List<string>() { ex.ToString() };

                return _response;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var product = await _productRepository.DeleteProduct(id);

                _response.IsSucess = product;

                return _response;
            }
            catch (System.Exception ex)
            {

                _response.IsSucess = false;
                _response.Errors = new System.Collections.Generic.List<string>() { ex.ToString() };

                return _response;
            }
        }

    }
}
