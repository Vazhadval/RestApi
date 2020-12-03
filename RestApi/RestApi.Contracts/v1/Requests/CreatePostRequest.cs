using System.Collections.Generic;

namespace RestApi.Contracts.v1.Requests
{
    public class CreatePostRequest
    {
        public string Name { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

}
