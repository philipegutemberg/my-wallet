using ProviderManagement.Enums;

namespace ProviderManagement.Providers.Factory
{
    internal interface IProviderServiceFactory
    {
        IProviderService Get(EnumProvider providerId);
    }
}