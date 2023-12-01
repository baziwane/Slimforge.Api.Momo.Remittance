// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class FailedAuthorizationServiceException : Xeption
    {
        public FailedAuthorizationServiceException(Exception innerException)
            : base(
                message: "Failed authorization error occurred, contact support.",
                    innerException: innerException)
        { }

        public FailedAuthorizationServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}