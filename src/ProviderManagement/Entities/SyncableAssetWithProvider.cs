using Domain.Entities;
using ProviderManagement.Enums;
using ProviderManagement.Models;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Entities
{
    public class SyncableAssetWithProvider : Asset, IModelWithProvider, ISyncableEntity
    {
        public SyncableAssetWithProvider(int id, string name, int financialInstitutionId, int providerId, string externalIdOnProvider)
            : base(id, name, financialInstitutionId)
        {
            ProviderId = (EnumProvider)providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public SyncableAssetWithProvider(string name, int financialInstitutionId, EnumProvider providerId, string externalIdOnProvider)
            : base(name, financialInstitutionId)
        {
            ProviderId = providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public EnumProvider ProviderId { get; }
        public string ExternalIdOnProvider { get; }

        public void AssignId(int id) => Id = id;

        public string GetSyncId() => ExternalIdOnProvider;
    }
}