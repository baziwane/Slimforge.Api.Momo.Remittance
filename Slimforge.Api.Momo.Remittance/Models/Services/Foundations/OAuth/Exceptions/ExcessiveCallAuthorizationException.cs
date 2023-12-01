// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class ExcessiveCallAuthorizationException : Xeption
    {
        public ExcessiveCallAuthorizationException(Exception innerException)
            : base(
                message: "Excessive call error occurred, limit your calls.",
                    innerException: innerException)
        { }

        public ExcessiveCallAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}