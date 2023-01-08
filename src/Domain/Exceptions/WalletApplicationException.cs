using System;

namespace Domain.Exceptions
{
    public abstract class WalletApplicationException : Exception
    {
        protected WalletApplicationException(string message)
            : base(message)
        {
        }

        protected WalletApplicationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}