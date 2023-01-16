using System.Runtime.InteropServices.ObjectiveC;
using Domain.Entities;
using ProviderManagement.Enums;
using ProviderManagement.Models;

namespace ProviderManagement.Entities
{
    public class AssetWithProvider : Asset, IModelWithProvider
    {
        public AssetWithProvider(string name, int financialInstitutionId, EnumProvider providerId, string externalIdOnProvider)
            : base(name, financialInstitutionId)
        {
            ProviderId = providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public AssetWithProvider(int id, string name, int financialInstitutionId, EnumProvider providerId, string externalIdOnProvider)
            : base(id, name, financialInstitutionId)
        {
            ProviderId = providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public EnumProvider ProviderId { get; }
        public string ExternalIdOnProvider { get; }
    }
}