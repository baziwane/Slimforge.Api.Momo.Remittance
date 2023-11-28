// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class RemittanceValidationException : Xeption
    {
        public RemittanceValidationException(Xeption innerException)
            : base(
                message: "Remittance validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public RemittanceValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
