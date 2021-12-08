using AutoMapper;
using Bob.Services.ShopCartAPI.Models;
using Bob.Services.ShopCartAPI.Models.Dto;
using Manage.Services.ShopCartAPI;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Services.ShopCartAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CartRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeaderFromDb = await _context.CartHeader.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            if (cartHeaderFromDb != null)
            {
                _context.CartDetails
                    .RemoveRange(_context.CartDetails.Where(u => u.CartHeaderId == cartHeaderFromDb.Id));
                _context.CartHeader.Remove(cartHeaderFromDb);
                await _context.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);

            var prodInDb = await _context.Product.AsNoTracking().FirstOrDefaultAsync(p => p.Id == cartDto.CartDetails.FirstOrDefault().ProductId);

            if (prodInDb == null)
            {
                _context.Product.Add(cart.CartDetails.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            var cartHeaderFromDb = await _context.CartHeader.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == cartDto.CartHeader.UserId);

            if(cartHeaderFromDb == null)
            {
                _context.CartHeader.Add(cart.CartHeader);
                await _context.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                var cartDetailsFromDb = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                        c => c.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                        c.CartHeaderId == cartHeaderFromDb.Id
                    );

                if(cartDetailsFromDb == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Update
                    cart.CartDetails.FirstOrDefault().Count += cartDetailsFromDb.Count;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeader.FirstOrDefaultAsync(u => u.Id == int.Parse(userId))
            };

            cart.CartDetails = _context.CartDetails
                .Where(u => u.CartHeaderId == cart.CartHeader.Id).Include(u => u.Product);

            return _mapper.Map<CartDto>(cart); ;
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                CartDetails cartDetails = await _context.CartDetails
                    .FirstOrDefaultAsync(u => u.Id == cartDetailsId);

                int totalCountOfCartItems = _context.CartDetails
                    .Where(u => u.CartHeaderId == cartDetails.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetails);
                if (totalCountOfCartItems == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeader
                        .FirstOrDefaultAsync(u => u.Id == cartDetails.CartHeaderId);

                    _context.CartHeader.Remove(cartHeaderToRemove);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
    }
}
