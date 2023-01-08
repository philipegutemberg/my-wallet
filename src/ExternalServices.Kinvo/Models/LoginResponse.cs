namespace ExternalServices.Kinvo.Models
{
    internal record LoginResponse : KinvoBaseResponse<LoginResponse.Token>
    {
        public class Token
        {
            public string AccessToken { get; init; } = "";
            public string RefreshToken { get; init; } = "";
        }
    }
}