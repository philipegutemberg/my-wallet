using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAssetPositionRepository
    {
        Task<AssetPosition> Add(AssetPosition assetPosition);

        Task<AssetPosition> Get(int assetId);
    }
}