// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Clients.OAuth.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the completion client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class AuthorizationClientDependencyException : Xeption
    {
        public AuthorizationClientDependencyException(Xeption innerException)
            : base(
                message: "Authorization dependency error occurred, contact support.",
                    innerException: innerException)
        { }

        public AuthorizationClientDependencyException(string message, Xeption innerException)
           : base(message, innerException)
        { }
    }
}
