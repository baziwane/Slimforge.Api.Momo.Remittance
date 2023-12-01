// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class FailedServerAuthorizationException : Xeption
    {
        public FailedServerAuthorizationException(Exception innerException)
            : base(
                message: "Failed server authorization error occurred, contact support.",
                    innerException: innerException)
        { }

        public FailedServerAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}