using Domain.Entities;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Entities;

public class SyncableAssetPosition : AssetPosition, ISyncableEntity
{
    public SyncableAssetPosition(
        int assetId,
        string assetName,
        int financialInstitutionId,
        int? portfolioDimensionId,
        decimal financialPosition,
        decimal appliedValue,
        decimal profitability,
        decimal portfolioPercentage)
        : base(assetId, assetName, financialInstitutionId, portfolioDimensionId, financialPosition, appliedValue, profitability, portfolioPercentage)
    {
    }

    public SyncableAssetPosition(AssetPosition assetPosition)
        : base(
            assetPosition.Asset.Id,
            assetPosition.Asset.Name,
            assetPosition.Asset.FinancialInstitutionId,
            assetPosition.Asset.PortfolioDimensionId,
            assetPosition.FinancialPosition,
            assetPosition.AppliedValue,
            assetPosition.Profitability,
            assetPosition.PortfolioPercentage)
    {
    }

    public string GetSyncId() => Asset.Id.ToString();
}