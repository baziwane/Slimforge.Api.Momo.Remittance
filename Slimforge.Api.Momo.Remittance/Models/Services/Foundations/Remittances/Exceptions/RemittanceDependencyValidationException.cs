// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances.Exceptions
{
    public class RemittanceDependencyValidationException : Xeption
    {
        public RemittanceDependencyValidationException(Xeption innerException)
            : base(
                message: "Remittance dependency validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public RemittanceDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}