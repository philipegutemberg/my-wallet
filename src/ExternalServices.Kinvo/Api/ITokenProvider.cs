using System.Threading.Tasks;
using ExternalServices.Kinvo.Models;
using Refit;

namespace ExternalServices.Kinvo.Api
{
    internal interface ITokenProvider
    {
        [Post("/v3/auth/login")]
        Task<LoginResponse> Login([Body] LoginRequest request);
    }
}