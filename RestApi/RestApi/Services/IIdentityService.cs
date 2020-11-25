
using RestApi.Domain;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
