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
using Slimforge.Api.Momo.Remittance.Brokers.DateTimes;
using Slimforge.Api.Momo.Remittance.Brokers.MomoApis;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Services.Foundations.OAuth;
using Tynamix.ObjectFiller;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Unit.Services.Foundations.OAuth
{
    public partial class AuthorizationServiceTests
    {
        private readonly Mock<IMomoBroker> momoBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IAuthorizationService authorizationService;

        public AuthorizationServiceTests()
        {
            this.momoBrokerMock = new Mock<IMomoBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.compareLogic = new CompareLogic();

            this.authorizationService = new AuthorizationService(
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
        
        private static dynamic CreateRandomAuthorizationProperties()
        {
            return new
            {
                AuthorizationResponse = CreateRandomAuthorizationResponseProperties()
            };
        }

        private static dynamic CreateRandomAuthorizationResponseProperties()
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

        private static Authorization CreateRandomAuthorization() =>
            CreateAuthorizationFiller().Create();

        private static Filler<Authorization> CreateAuthorizationFiller()
        {
            var filler = new Filler<Authorization>();

            filler.Setup()
                .OnType<object>().IgnoreIt();

            return filler;
        }
    }
}
