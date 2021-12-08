using System.Collections.Generic;

namespace Manage.Services.ProductAPI.Models.DTOs
{
    public class ResponseDto
    {
        public bool IsSucess { get; set; } = true;
        public object Data { get; set; }
        public string Menssage { get; set; }
        public List<string> Errors { get; set; }
    }
}
