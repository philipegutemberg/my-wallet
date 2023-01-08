namespace Domain.Models
{
    public record AssetPosition
    {
        public AssetPosition(
            int assetId,
            string assetName,
            int financialInstitutionId,
            decimal financialPosition,
            decimal appliedValue,
            decimal profitability,
            decimal walletPercentage)
        {
            Asset = new Asset(assetId, assetName, financialInstitutionId);
            FinancialPosition = financialPosition;
            AppliedValue = appliedValue;
            Profitability = profitability;
            WalletPercentage = walletPercentage;
        }

        public Asset Asset { get; }
        public decimal FinancialPosition { get; }
        public decimal AppliedValue { get; }
        public decimal Profitability { get; }
        public decimal WalletPercentage { get; }
    }
}