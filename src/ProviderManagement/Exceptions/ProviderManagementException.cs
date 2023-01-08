using System;
using Domain.Exceptions;

namespace ProviderManagement.Exceptions
{
    internal class ProviderManagementException : WalletApplicationException
    {
        public ProviderManagementException(string message)
            : base(message)
        {
        }

        public ProviderManagementException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}