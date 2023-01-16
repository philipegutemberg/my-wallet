using System;
using ProviderManagement.Enums;
using ProviderManagement.Exceptions;

namespace ProviderManagement.Providers.Factory
{
    internal class ProviderServiceFactory : IProviderServiceFactory
    {
        private readonly IKinvoProviderService _kinvoProviderService;

        public ProviderServiceFactory(IKinvoProviderService kinvoProviderService)
        {
            _kinvoProviderService = kinvoProviderService;
        }

        public IProviderService Get(EnumProvider providerId)
        {
            switch (providerId)
            {
                case EnumProvider.Kinvo:
                    return _kinvoProviderService;
                default:
                    throw new ProviderManagementException($"Provider not found: {providerId}.");
            }
        }
    }
}