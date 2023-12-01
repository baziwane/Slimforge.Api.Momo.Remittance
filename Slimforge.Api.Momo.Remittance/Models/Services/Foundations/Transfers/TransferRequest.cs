// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Transfers
{
    public class TransferRequest
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string ExternalId { get; set; }
        public Payee Payee { get; set; }
        public string PayerMessage { get; set; }
        public string PayeeNote { get; set; }
    }
}