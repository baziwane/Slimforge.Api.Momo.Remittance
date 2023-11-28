// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.DependencyInjection;
using Slimforge.Api.Momo.Brokers.DateTimes;
using Slimforge.Api.Momo.Brokers.MomoApis;
using Slimforge.Api.Momo.Clients.Remittances;
using Slimforge.Api.Momo.Models.Configurations;
using Slimforge.Api.Momo.Services.Foundations.Remittances;


namespace Slimforge.Api.Momo.Clients.MomoApis
{
    public partial class MomoClient : IMomoClient
    {
        public IRemittanceClient AccessTokens { get; private set; }
    }
}
