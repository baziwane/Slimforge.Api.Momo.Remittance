// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.DependencyInjection;
using Slimforge.Api.Momo.Remittance.Brokers.DateTimes;
using Slimforge.Api.Momo.Remittance.Brokers.MomoApis;
using Slimforge.Api.Momo.Remittance.Clients.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Configurations;
using Slimforge.Api.Momo.Remittance.Services.Foundations.Remittances;


namespace Slimforge.Api.Momo.Remittance.Clients.MomoApis
{
    public partial class MomoClient : IMomoClient
    {
        public IRemittanceClient AccessTokens { get; private set; }
    }
}
