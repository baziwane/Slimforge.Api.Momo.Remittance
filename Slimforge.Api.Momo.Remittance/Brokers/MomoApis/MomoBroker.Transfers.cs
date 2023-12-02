// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalTransfers;

namespace Slimforge.Api.Momo.Remittance.Brokers.MomoApis
{
    internal partial class MomoBroker
    {
        public async ValueTask<ExternalTransferResponse> PostTransferRequestAsync(ExternalTransferRequest transferRequest) =>
            await PostAsync<ExternalTransferRequest, ExternalTransferResponse>(relativeUrl: "remittance/v1_0/transfer", transferRequest);
    }
}