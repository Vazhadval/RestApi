using System.Collections.Generic;

namespace RestApi.Contracts.v1.Requests
{
    public class CreatePostRequest
    {
        public string Name { get; set; }
        public IEnumerable<TagForPostCreation> Tags { get; set; }

        public class TagForPostCreation
        {
            public string Name { get; set; }
        }
    }

}
