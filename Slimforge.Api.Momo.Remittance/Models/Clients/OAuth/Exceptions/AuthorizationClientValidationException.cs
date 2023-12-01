// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Clients.OAuth.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class AuthorizationClientValidationException : Xeption
    {
        public AuthorizationClientValidationException(Xeption innerException)
            : base(
                message: "Authorization client validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public AuthorizationClientValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
