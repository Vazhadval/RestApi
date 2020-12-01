using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Contracts.v1.Requests
{
    public class CreateTagRequest
    {
        public string Name { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreaterOn { get; set; }
    }
}
