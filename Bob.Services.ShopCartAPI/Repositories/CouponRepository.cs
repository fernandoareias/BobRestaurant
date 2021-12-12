using Bob.Services.ShopCartAPI.Models.DTOs;
using Manage.Services.ShopCartAPI.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bob.Services.ShopCartAPI.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient client;

        public CouponRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<CouponDto> GetCoupon(string couponName)
        {
            var response = await client.GetAsync($"/api/coupon/{couponName}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.IsSucess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Data));
            }
            return new CouponDto();
        }
    }
}
