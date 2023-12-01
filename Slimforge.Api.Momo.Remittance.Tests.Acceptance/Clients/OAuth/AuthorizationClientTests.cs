// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using System;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;
using Slimforge.Api.Momo.Remittance.Clients.MomoApis;
using Slimforge.Api.Momo.Remittance.Models.Configurations;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Tynamix.ObjectFiller;
using Xunit;
using WireMock.Server;

namespace Slimforge.Api.Momo.Remittance.Tests.Acceptance.Clients.OAuth
{
    public partial class AuthorizationClientTests : IDisposable
    {
        private readonly IMomoClient momoClient;
        private readonly WireMockServer wireMockServer;
        private readonly string apiKey;
        private readonly string apiUser;
        private readonly string subscriptionKey;

        public AuthorizationClientTests()
        {
            this.wireMockServer = WireMockServer.Start();
            this.apiKey = CreateRandomString();
            this.apiUser = CreateRandomString();
            this.subscriptionKey = CreateRandomString();

            var momoConfigurations = new MomoConfigurations
            {
                BaseUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,
                ApiUser = this.apiUser,
                SubscriptionKey = this.subscriptionKey,
                TargetEnvironment = "sandbox"
            };

            this.momoClient = new MomoClient(momoConfigurations);
        }


        private static Authorization ConvertToAuthorization(
           Authorization authorization,
           ExternalAuthorizationResponse externalAuthorizationResponse)
        {
            authorization.Response = new AuthorizationResponse
            {
                AccessToken = externalAuthorizationResponse.AccessToken,
                ExpiresIn = externalAuthorizationResponse.ExpiresIn,
                TokenType = externalAuthorizationResponse.TokenType
            };

            return authorization;
        }

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        //private static string CreateRandomString() =>
        //  new MnemonicString().GetValue();

        private static string CreateRandomString() =>
            new Guid().ToString();
        
        private static Authorization CreateRandomAuthorization() =>
            CreateAuthorizationFiller().Create();

        private static ExternalAuthorizationResponse CreateRandomExternalAuthorizationResponse() =>
            CreateAuthorizationResponseFiller().Create();

        private static Filler<ExternalAuthorizationResponse> CreateAuthorizationResponseFiller()
        {
            var filler = new Filler<ExternalAuthorizationResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<Authorization> CreateAuthorizationFiller()
        {
            var filler = new Filler<Authorization>();

            filler.Setup()
                .OnType<object>().IgnoreIt();

            return filler;
        }

        public void Dispose() => this.wireMockServer.Stop();
    }
}