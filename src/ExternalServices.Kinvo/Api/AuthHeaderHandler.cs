using System.Net.Http.Headers;
using ExternalServices.Kinvo.Models;

namespace ExternalServices.Kinvo.Api
{
    internal class AuthHeaderHandler : DelegatingHandler
    {
        private readonly ITokenProvider _tokenProvider;

        public AuthHeaderHandler(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LoginResponse loginResponse = await this._tokenProvider.Login(new LoginRequest
            {
                Email = "gutembergphilipe@gmail.com",
                Password = "laurinha"
            });

            var token = loginResponse.GetResponse().AccessToken;

            //potentially refresh token here if it has expired etc.

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}