// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Models.Clients.Remittances.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the completion client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class RemittanceClientServiceException : Xeption
    {
        public RemittanceClientServiceException(Xeption innerException)
            : base(
                message: "Remittance client service error occurred, contact support.",
                    innerException: innerException)
        { }

        public RemittanceClientServiceException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
