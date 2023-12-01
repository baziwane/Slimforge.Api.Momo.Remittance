// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class UnauthorizedAuthorizationException : Xeption
    {
        public UnauthorizedAuthorizationException(Exception innerException)
            : base(
                message: "Unauthorized authorization request, fix errors and try again.",
                    innerException: innerException)
        { }

        public UnauthorizedAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}