using System.Collections.Generic;

namespace Bob.Web.Models
{
    public class ResponseDto
    {
        public bool IsSucess { get; set; } = true;
        public object Data { get; set; }
        public string Menssage { get; set; }
        public List<string> Errors { get; set; }
    }
}
