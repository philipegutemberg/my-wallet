using Domain.Enums;

namespace Domain.Entities
{
    public class AssetDimension
    {
        public AssetDimension(int assetId, EnumAssetDimension assetDimensionId, decimal idealAllocationPercentage)
        {
            AssetId = assetId;
            AssetDimensionId = assetDimensionId;
            IdealAllocationPercentage = idealAllocationPercentage;
        }

        public int AssetId { get; }
        public EnumAssetDimension AssetDimensionId { get; }
        public decimal IdealAllocationPercentage { get; }
    }
}