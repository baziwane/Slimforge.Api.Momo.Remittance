// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions
{
    public class NullAuthorizationException : Xeption
    {
        public NullAuthorizationException()
            : base(
                message: "Authorization is null.")
        { }

        public NullAuthorizationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}