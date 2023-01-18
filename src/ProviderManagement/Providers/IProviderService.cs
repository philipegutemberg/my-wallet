using ProviderManagement.Models;

namespace ProviderManagement.Providers
{
    internal interface IProviderService
    {
        Task<IEnumerable<ProviderAssetPosition>> GetPositions();

        Task<IEnumerable<ProviderAssetMovement>> GetMovements();

        Task<IEnumerable<ProviderAssetEvent>> GetEvents();
    }
}