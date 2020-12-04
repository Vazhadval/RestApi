using RestApi.Contracts.v1.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);
        Uri GetAllPostUri(PaginationQuery paginationQuery);
    }
}
