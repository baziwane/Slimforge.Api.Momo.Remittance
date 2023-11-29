// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using Slimforge.Api.Momo.Brokers.DateTimes;
using Slimforge.Api.Momo.Brokers.MomoApis;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Services.Foundations.Remittances;
using Tynamix.ObjectFiller;
using Xunit;

namespace Slimforge.Api.Momo.Tests.Unit.Services.Foundations.Remittances
{
    public partial class RemittanceServiceTests
    {
        private readonly Mock<IMomoBroker> momoBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IRemittanceService remittanceService;

        public RemittanceServiceTests()
        {
            this.momoBrokerMock = new Mock<IMomoBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.compareLogic = new CompareLogic();

            this.remittanceService = new RemittanceService(
                momoBroker: this.momoBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }

        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }
        
        private static dynamic CreateRandomAccessTokenProperties()
        {
            return new
            {
               AccessToken = GetRandomString(),
               TokenType = "access_token",
               ExpiresIn = GetRandomNumber()
            };
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();

        private static AccessTokenResponse CreateRandomAccessToken() =>
            CreateAccessTokenFiller().Create();

        private static Filler<AccessTokenResponse> CreateAccessTokenFiller()
        {
            var filler = new Filler<AccessTokenResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt();

            return filler;
        }
    }
}
