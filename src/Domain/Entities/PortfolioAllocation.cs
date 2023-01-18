namespace Domain.Entities;

public class PortfolioAllocation
{
    public PortfolioAllocation(int id, int? dimensionId, int? assetId, decimal percentage)
    {
        Id = id;
        DimensionId = dimensionId;
        AssetId = assetId;
        Percentage = percentage;
    }

    public PortfolioAllocation(decimal percentage, int? dimensionId = null, int? assetId = null)
    {
        Percentage = percentage;
        DimensionId = dimensionId;
        AssetId = assetId;
    }

    public int Id { get; }
    public int? DimensionId { get; }
    public int? AssetId { get; }
    public decimal Percentage { get; }

    public static PortfolioAllocation FromDimension(int dimensionId, decimal percentage) =>
        new(percentage, dimensionId: dimensionId);

    public static PortfolioAllocation FromAsset(int assetId, decimal percentage) =>
        new(percentage, assetId: assetId);
}