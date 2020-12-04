using RestApi.Contracts.v1.Requests.Queries;
using RestApi.Contracts.v1.Responses;
using RestApi.Domain;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Helpers
{
    public class PaginationHelpers
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter pagination, List<T> response)
        {
            var nextPage = pagination.PageNumber >= 1
               ? uriService.GetAllPostUri(new PaginationQuery(pagination.PageNumber + 1, pagination.PageSize)).ToString()
               : null;
            var previousPage = pagination.PageNumber - 1 >= 1
                ? uriService.GetAllPostUri(new PaginationQuery(pagination.PageNumber - 1, pagination.PageSize)).ToString()
                : null;


            return new PagedResponse<T>
            {
                Data = response,
                pageSize = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
                PageNumber = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null,
                NextPage = response.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }

    }
}
