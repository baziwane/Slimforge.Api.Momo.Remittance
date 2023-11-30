// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Brokers.DateTimes;
using Slimforge.Api.Momo.Remittance.Brokers.MomoApis;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalRemittances;

namespace Slimforge.Api.Momo.Remittance.Services.Foundations.Remittances
{
    internal partial class RemittanceService : IRemittanceService
    {
        public ValueTask<AccessTokenResponse> GenerateAccessTokenAsync() =>
        TryCatch(async () =>
        {
            ExternalAccessTokenResponse accessTokenResponse =
                await PostAccessTokenRequestAsync();

            return ConvertToAccessTokenResponse(accessTokenResponse);
        });

        private async Task<ExternalAccessTokenResponse> PostAccessTokenRequestAsync()
        {
            ExternalAccessTokenResponse externalAccessTokenResponse =
                await this.momoBroker.PostAccessTokenRequestAsync(); 

            return externalAccessTokenResponse;
        }

        private AccessTokenResponse ConvertToAccessTokenResponse(
            ExternalAccessTokenResponse externalAccessTokenResponse)

        {
            return new AccessTokenResponse
            {
                AccessToken = externalAccessTokenResponse.AccessToken,
                ExpiresIn = externalAccessTokenResponse.ExpiresIn,
                TokenType = externalAccessTokenResponse.TokenType
            };
        }
    }
}