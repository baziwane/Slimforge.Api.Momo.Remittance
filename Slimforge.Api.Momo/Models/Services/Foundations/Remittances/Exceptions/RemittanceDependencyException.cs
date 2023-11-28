// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class RemittanceDependencyException : Xeption
    {
        public RemittanceDependencyException(Xeption innerException)
            : base(
                message: "Remittance dependency error occurred, contact support.",
                    innerException: innerException)
        { }

        public RemittanceDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}