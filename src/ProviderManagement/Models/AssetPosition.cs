namespace ProviderManagement.Models
{
    internal record AssetPosition
    {
        public string Id { get; init; } = "";
        public string AssetId { get; init; } = "";
        public string AssetName { get; init; } = "";
        public string FinancialInstitutionId { get; init; } = "";
        public string FinancialInstitutionName { get; init; } = "";
        public decimal FinancialPosition { get; init; }
        public decimal AppliedValue { get; init; }
        public decimal Profitability { get; init; }
        public decimal PortfolioPercentage { get; init; }
    }
}