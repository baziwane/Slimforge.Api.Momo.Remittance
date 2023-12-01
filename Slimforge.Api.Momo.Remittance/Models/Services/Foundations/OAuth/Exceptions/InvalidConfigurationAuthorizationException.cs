// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class InvalidConfigurationAuthorizationException : Xeption
    {
        public InvalidConfigurationAuthorizationException(Exception innerException)
            : base(
                message: "Invalid configuration error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public InvalidConfigurationAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}