namespace Domain.Entities
{
    public class AssetPosition
    {
        public AssetPosition(
            int assetId,
            string assetName,
            int financialInstitutionId,
            int? portfolioDimensionId,
            decimal financialPosition,
            decimal appliedValue,
            decimal profitability,
            decimal portfolioPercentage)
        {
            Asset = new Asset(assetId, assetName, financialInstitutionId, portfolioDimensionId);
            FinancialPosition = financialPosition;
            AppliedValue = appliedValue;
            Profitability = profitability;
            PortfolioPercentage = portfolioPercentage;
        }

        public Asset Asset { get; }
        public decimal FinancialPosition { get; }
        public decimal AppliedValue { get; }
        public decimal Profitability { get; }
        public decimal PortfolioPercentage { get; }
    }
}