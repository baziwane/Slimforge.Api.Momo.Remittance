// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class AuthorizationDependencyValidationException : Xeption
    {
        public AuthorizationDependencyValidationException(Xeption innerException)
            : base(
                message: "Authorization dependency validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public AuthorizationDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}