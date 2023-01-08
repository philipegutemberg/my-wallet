namespace ExternalServices.Kinvo.Models
{
    internal record LoginRequest
    {
        public string Email { get; init; } = "";
        public string Password { get; init; } = "";
    }
}