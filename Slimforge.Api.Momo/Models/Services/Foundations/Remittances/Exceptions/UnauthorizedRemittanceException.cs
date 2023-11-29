// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class UnauthorizedRemittanceException : Xeption
    {
        public UnauthorizedRemittanceException(Exception innerException)
            : base(
                message: "Unauthorized remittance request, fix errors and try again.",
                    innerException: innerException)
        { }

        public UnauthorizedRemittanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}