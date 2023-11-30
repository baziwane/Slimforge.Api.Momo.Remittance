// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances.Exceptions
{
    public class NullRemittanceException : Xeption
    {
        public NullRemittanceException()
            : base(
                message: "Remittance is null.")
        { }

        public NullRemittanceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}