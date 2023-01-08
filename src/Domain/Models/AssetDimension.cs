using Domain.Enums;

namespace Domain.Models
{
    public class AssetDimension
    {
        public AssetDimension(int assetId, EnumAssetDimension dimension, decimal idealAllocationPercentage)
        {
            AssetId = assetId;
            Dimension = dimension;
            IdealAllocationPercentage = idealAllocationPercentage;
        }

        public int AssetId { get; }
        public EnumAssetDimension Dimension { get; }
        public decimal IdealAllocationPercentage { get; }
    }
}