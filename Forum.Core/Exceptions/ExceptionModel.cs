using Newtonsoft.Json;

namespace Forum.Core.Exceptions
{
    public class ExceptionModel
    {
        public int StatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
       
    }

}
