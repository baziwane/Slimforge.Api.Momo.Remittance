// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using System;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalRemittances;
using Slimforge.Api.Momo.Remittance.Clients.MomoApis;
using Slimforge.Api.Momo.Remittance.Models.Configurations;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Tynamix.ObjectFiller;
using Xunit;
using WireMock.Server;

namespace Slimforge.Api.Momo.Remittance.Tests.Acceptance.Clients.Remittances
{
    public partial class RemittanceClientTests : IDisposable
    {
        private readonly IMomoClient momoClient;
        private readonly WireMockServer wireMockServer;
        private readonly string apiKey;
        private readonly string apiUser;
        private readonly string subscriptionKey;

        public RemittanceClientTests()
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


        private static AccessToken ConvertToAccessToken(
           AccessToken accessToken,
           ExternalAccessTokenResponse externalAccessTokenResponse)
        {
            accessToken.Response = new AccessTokenResponse
            {
                AccessToken = externalAccessTokenResponse.AccessToken,
                ExpiresIn = externalAccessTokenResponse.ExpiresIn,
                TokenType = externalAccessTokenResponse.TokenType
            };

            return accessToken;
        }

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static AccessToken CreateRandomAccessToken() =>
            CreateAccessTokenFiller().Create();

        private static ExternalAccessTokenResponse CreateRandomExternalAccessTokenResponse() =>
            CreateAccessTokenResponseFiller().Create();

        private static Filler<ExternalAccessTokenResponse> CreateAccessTokenResponseFiller()
        {
            var filler = new Filler<ExternalAccessTokenResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<AccessToken> CreateAccessTokenFiller()
        {
            var filler = new Filler<AccessToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt();

            return filler;
        }

        public void Dispose() => this.wireMockServer.Stop();
    }
}