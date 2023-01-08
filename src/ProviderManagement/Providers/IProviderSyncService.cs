using System.Threading.Tasks;
using ProviderManagement.Enums;

namespace ProviderManagement.Providers
{
    public interface IProviderSyncService
    {
        Task Sync(EnumProvider provider);
    }
}