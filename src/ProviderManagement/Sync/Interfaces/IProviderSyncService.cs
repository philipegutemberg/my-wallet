using System.Threading.Tasks;
using ProviderManagement.Enums;

namespace ProviderManagement.Sync.Interfaces
{
    public interface IProviderSyncService
    {
        Task Sync(EnumProvider providerId);
    }
}