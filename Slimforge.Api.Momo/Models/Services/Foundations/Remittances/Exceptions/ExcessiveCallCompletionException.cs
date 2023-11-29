// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class ExcessiveCallRemittanceException : Xeption
    {
        public ExcessiveCallRemittanceException(Exception innerException)
            : base(
                message: "Excessive call error occurred, limit your calls.",
                    innerException: innerException)
        { }

        public ExcessiveCallRemittanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}