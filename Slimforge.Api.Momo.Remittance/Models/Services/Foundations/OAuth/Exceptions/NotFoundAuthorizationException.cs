// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class NotFoundAuthorizationException : Xeption
    {
        public NotFoundAuthorizationException(Exception innerException)
            : base(
                message: "Not found authorization error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public NotFoundAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}