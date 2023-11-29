// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Models.Clients.Remittances.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class RemittanceClientValidationException : Xeption
    {
        public RemittanceClientValidationException(Xeption innerException)
            : base(
                message: "Remittance client validation error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public RemittanceClientValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
