﻿using Bob.Services.ShopCartAPI.Models.Dto;
using System.Threading.Tasks;

namespace Bob.Services.ShopCartAPI.Repositories
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);
    }
}