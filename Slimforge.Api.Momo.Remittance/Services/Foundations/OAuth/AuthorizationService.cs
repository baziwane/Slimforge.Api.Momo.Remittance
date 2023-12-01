// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Brokers.DateTimes;
using Slimforge.Api.Momo.Remittance.Brokers.MomoApis;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;

namespace Slimforge.Api.Momo.Remittance.Services.Foundations.OAuth
{
    internal partial class AuthorizationService : IAuthorizationService
    {
        private readonly IMomoBroker momoBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public AuthorizationService(
            IMomoBroker momoBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.momoBroker = momoBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Authorization> PromptAuthorizationAsync() =>
        TryCatch(async () =>
        {
            ExternalAuthorizationResponse authorizationResponse =
                await PostAuthorizationRequestAsync();

            return ConvertToAuthorization(authorizationResponse);
        });

        private async Task<ExternalAuthorizationResponse> PostAuthorizationRequestAsync()
        {
            ExternalAuthorizationResponse externalAuthorizationResponse =
                await this.momoBroker.PostAuthorizationRequestAsync(); 

            return externalAuthorizationResponse;
        }

        private Authorization ConvertToAuthorization(
            ExternalAuthorizationResponse externalAuthorizationResponse)

        {
            var authorization = new Authorization
            {
                Response = new AuthorizationResponse
                {
                    AccessToken = externalAuthorizationResponse.AccessToken,
                    ExpiresIn = externalAuthorizationResponse.ExpiresIn,
                    TokenType = externalAuthorizationResponse.TokenType
                }
            };
            return authorization;
        }
       
    }
}