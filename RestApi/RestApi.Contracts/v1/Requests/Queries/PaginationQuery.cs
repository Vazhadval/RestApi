using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Contracts.v1.Requests.Queries
{
    public class PaginationQuery
    {
        private const int _defaultPageSize = 100;
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = _defaultPageSize;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = PageSize > 100 ? _defaultPageSize : pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
