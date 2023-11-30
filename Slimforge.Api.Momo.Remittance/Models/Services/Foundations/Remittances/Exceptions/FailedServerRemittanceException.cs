// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances.Exceptions
{
    public class FailedServerRemittanceException : Xeption
    {
        public FailedServerRemittanceException(Exception innerException)
            : base(
                message: "Failed server remittance error occurred, contact support.",
                    innerException: innerException)
        { }

        public FailedServerRemittanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}