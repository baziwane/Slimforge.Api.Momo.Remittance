// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Transfers
{
    public class TransferResponse
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string FinancialTransactionId { get; set; }
        public string ExternalId { get; set; }
        public Payee Payee { get; set; }
        public string PayerMessage { get; set; }
        public string PayeeNote { get; set; }
        public string Status { get; set; }
        
    }
}

/*
{
    "amount": "2000",
    "currency": "EUR",
    "financialTransactionId": "506567530",
    "externalId": "46733123453",
    "payee": {
        "partyIdType": "MSISDN",
        "partyId": "46733129001"
    },
    "payerMessage": "helloworld",
    "payeeNote": "weareherenow",
    "status": "SUCCESSFUL"
}
        
    */