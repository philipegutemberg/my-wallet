using ProviderManagement.Enums;

namespace ProviderManagement.Models
{
    public interface IModelWithProvider
    {
        EnumProvider ProviderId { get; }
        string ExternalIdOnProvider { get; }
    }
}