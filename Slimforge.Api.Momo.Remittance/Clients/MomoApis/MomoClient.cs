// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.DependencyInjection;
using Slimforge.Api.Momo.Remittance.Brokers.DateTimes;
using Slimforge.Api.Momo.Remittance.Brokers.MomoApis;
using Slimforge.Api.Momo.Remittance.Clients.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Configurations;
using Slimforge.Api.Momo.Remittance.Services.Foundations.Remittances;


namespace Slimforge.Api.Momo.Remittance.Clients.MomoApis
{
    public partial class MomoClient : IMomoClient
    {
        public MomoClient(MomoConfigurations momoConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(momoConfigurations);
            InitializeClients(serviceProvider);
        }
        //public IRemittanceClient Remittance { get; private set; }
    
        private void InitializeClients(IServiceProvider serviceProvider)
        {
            AccessTokens = serviceProvider.GetRequiredService<IRemittanceClient>();
        }

        private static IServiceProvider RegisterServices(MomoConfigurations momoConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IMomoBroker, MomoBroker>()
                .AddTransient<IDateTimeBroker, DateTimeBroker>()
                .AddTransient<IRemittanceService, RemittanceService>()
                .AddTransient<IRemittanceClient, RemittanceClient>()
                .AddSingleton(momoConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
