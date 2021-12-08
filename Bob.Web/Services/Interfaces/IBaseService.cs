using Bob.Web.Models;
using System;
using System.Threading.Tasks;

namespace Bob.Web.Services.Interfaces
{
    public interface IBaseService
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
