// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions
{
    public class InvalidConfigurationRemittanceException : Xeption
    {
        public InvalidConfigurationRemittanceException(Exception innerException)
            : base(
                message: "Invalid configuration error occurred, fix errors and try again.",
                    innerException: innerException)
        { }

        public InvalidConfigurationRemittanceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}