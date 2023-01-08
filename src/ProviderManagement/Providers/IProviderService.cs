using System.Collections.Generic;
using System.Threading.Tasks;
using ProviderManagement.Models;

namespace ProviderManagement.Providers
{
    internal interface IProviderService
    {
        Task<IEnumerable<AssetPosition>> GetPositions();

        Task<IEnumerable<AssetMovement>> GetMovements();

        Task<IEnumerable<AssetEvent>> GetEvents();
    }
}