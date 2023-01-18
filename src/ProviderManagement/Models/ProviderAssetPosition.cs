using Domain.Entities;
using ProviderManagement.Entities;
using ProviderManagement.Enums;

namespace ProviderManagement.Models
{
    internal record ProviderAssetPosition
    {
        public EnumProvider ProviderId { get; init; }
        public string Id { get; init; } = "";
        public string AssetId { get; init; } = "";
        public string AssetName { get; init; } = "";
        public string FinancialInstitutionId { get; init; } = "";
        public string FinancialInstitutionName { get; init; } = "";
        public decimal FinancialPosition { get; init; }
        public decimal AppliedValue { get; init; }
        public decimal Profitability { get; init; }
        public decimal PortfolioPercentage { get; init; }

        public AssetPosition ToAssetPosition(SyncableAssetWithProvider assetWithProvider) =>
            new(
                assetWithProvider.Id,
                assetWithProvider.Name,
                assetWithProvider.FinancialInstitutionId,
                assetWithProvider.PortfolioDimensionId,
                FinancialPosition,
                AppliedValue,
                Profitability,
                PortfolioPercentage);

        public SyncableAssetPosition ToSyncableAssetPosition(SyncableAssetWithProvider assetWithProvider) =>
            new(
                assetWithProvider.Id,
                assetWithProvider.Name,
                assetWithProvider.FinancialInstitutionId,
                assetWithProvider.PortfolioDimensionId,
                FinancialPosition,
                AppliedValue,
                Profitability,
                PortfolioPercentage);
    }
}