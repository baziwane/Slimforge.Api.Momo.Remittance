// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class FailedRemittanceServiceException : Xeption
    {
        public FailedRemittanceServiceException(Exception innerException)
            : base(
                message: "Failed Remittance error occurred, contact support.",
                    innerException: innerException)
        { }

        public FailedRemittanceServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}