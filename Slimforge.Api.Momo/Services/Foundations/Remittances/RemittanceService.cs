// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Slimforge.Api.Momo.Brokers.DateTimes;
using Slimforge.Api.Momo.Brokers.MomoApis;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Models.Services.Foundations.ExternalRemittances;

namespace Slimforge.Api.Momo.Services.Foundations.Remittances
{
    internal partial class RemittanceService : IRemittanceService
    {
        private readonly IMomoBroker momoBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public RemittanceService(
            IMomoBroker momoBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.momoBroker = momoBroker;
            this.dateTimeBroker = dateTimeBroker;
        }
       
    }
}