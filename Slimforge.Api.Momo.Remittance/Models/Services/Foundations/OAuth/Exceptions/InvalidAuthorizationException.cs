// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class InvalidAuthorizationException : Xeption
    {
        public InvalidAuthorizationException()
            : base(
                message: "Invalid authorization error occurred, fix errors and try again.")
        { }

        public InvalidAuthorizationException(Exception innerException)
            : base(
                message: "Invalid authorization error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public InvalidAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}