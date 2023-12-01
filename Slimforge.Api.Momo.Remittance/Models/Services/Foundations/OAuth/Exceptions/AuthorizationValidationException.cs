// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class AuthorizationValidationException : Xeption
    {
        public AuthorizationValidationException(Xeption innerException)
            : base(
                message: "Authorization validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public AuthorizationValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
