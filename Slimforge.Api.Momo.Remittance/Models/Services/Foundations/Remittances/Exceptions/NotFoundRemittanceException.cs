// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances.Exceptions
{
    public class NotFoundRemittanceException : Xeption
    {
        public NotFoundRemittanceException(Exception innerException)
            : base(
                message: "Not found remittance error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public NotFoundRemittanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}