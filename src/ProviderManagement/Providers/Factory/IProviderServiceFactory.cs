using ProviderManagement.Enums;
using ProviderManagement.Services;

namespace ProviderManagement.Providers.Factory
{
    internal interface IProviderServiceFactory
    {
        IProviderService Get(EnumProvider provider);
    }
}