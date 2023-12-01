// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class AuthorizationServiceException : Xeption
    {
        public AuthorizationServiceException(Xeption innerException)
            : base(
                message: "Authorization service error occurred, contact support.",
                    innerException: innerException)
        { }

        public AuthorizationServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}