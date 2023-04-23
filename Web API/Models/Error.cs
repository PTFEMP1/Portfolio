using Newtonsoft.Json;

namespace Web_API.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string TraceId { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
