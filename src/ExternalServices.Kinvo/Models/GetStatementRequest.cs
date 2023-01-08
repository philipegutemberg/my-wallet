namespace ExternalServices.Kinvo.Models
{
    public record GetStatementRequest
    {
        public long PortfolioId { get; init; }
        public long Offset { get; init; }
        public long Fetch { get; init; }
    }
}