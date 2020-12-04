using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Contracts.v1.Responses
{
    public class PagedResponse<T>
    {
        public PagedResponse()
        {

        }

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? pageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
    }
}
