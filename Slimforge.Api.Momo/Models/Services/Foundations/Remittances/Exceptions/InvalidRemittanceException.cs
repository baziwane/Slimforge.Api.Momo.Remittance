// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class InvalidRemittanceException : Xeption
    {
        public InvalidRemittanceException()
            : base(
                message: "Invalid Remittance error occurred, fix errors and try again.")
        { }

        public InvalidRemittanceException(Exception innerException)
            : base(
                message: "Invalid Remittance error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public InvalidRemittanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}