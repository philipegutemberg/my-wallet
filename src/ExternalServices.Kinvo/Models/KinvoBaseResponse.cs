namespace ExternalServices.Kinvo.Models
{
    internal abstract record KinvoBaseResponse<TResponse>
    {
        public bool Success { get; init; }
        public TResponse? Data { get; init; }
        public ErrorResponse? Error { get; init; }

        public bool IsSuccessful() => Success && Data is not null && Error is null;

        public TResponse GetResponse() => Data!;
    }
}