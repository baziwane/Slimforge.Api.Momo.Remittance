// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class RemittanceServiceException : Xeption
    {
        public RemittanceServiceException(Xeption innerException)
            : base(
                message: "Remittance service error occurred, contact support.",
                    innerException: innerException)
        { }

        public RemittanceServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}