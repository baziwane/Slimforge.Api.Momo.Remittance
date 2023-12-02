// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalTransfers;

namespace Slimforge.Api.Momo.Brokers.MomoApis
{
    internal partial interface IMomoBroker
    {
        ValueTask<ExternalTransferResponse> PostTransferRequestAsync(ExternalTransferRequest transferRequest);
    }
}