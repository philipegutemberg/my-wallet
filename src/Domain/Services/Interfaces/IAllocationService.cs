namespace Domain.Services.Interfaces;

public interface IAllocationService
{
    Task AssignAllocation(int assetDimensionId, decimal percentage);

    Task AssignDimensionParentToDimension(int assetDimensionId, int assetDimensionParentId, decimal percentage);

    Task AssignDimensionToAsset(int assetId, int dimensionId, decimal percentage);
}