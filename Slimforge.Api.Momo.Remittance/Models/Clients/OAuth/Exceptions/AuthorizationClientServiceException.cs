// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Clients.OAuth.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the completion client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class AuthorizationClientServiceException : Xeption
    {
        public AuthorizationClientServiceException(Xeption innerException)
            : base(
                message: "Authorization client service error occurred, contact support.",
                    innerException: innerException)
        { }

        public AuthorizationClientServiceException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
