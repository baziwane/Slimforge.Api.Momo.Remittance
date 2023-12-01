// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Slimforge.Api.Momo.Remittance.Clients.MomoApis;
using Slimforge.Api.Momo.Remittance.Models.Configurations;

namespace Slimforge.Api.Momo.Remittance.Tests.Integration.APIs.OAuth
{
    public partial class AuthorizationApiTests
    {
        private readonly IMomoClient momoClient;

        public AuthorizationApiTests()
        {
            var momoConfigurations = new MomoConfigurations
            {
                ApiUser = Environment.GetEnvironmentVariable("ApiUser"),
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                SubscriptionKey = Environment.GetEnvironmentVariable("SubscriptionKey"),
                BaseUrl = "https://sandbox.momodeveloper.mtn.com/",
                TargetEnvironment = "sandbox"
            };

            this.momoClient = new MomoClient(momoConfigurations);
        }
    }
}