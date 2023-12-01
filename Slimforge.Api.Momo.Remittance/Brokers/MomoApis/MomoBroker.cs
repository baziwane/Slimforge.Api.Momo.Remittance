// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RESTFulSense.Clients;
using Slimforge.Api.Momo.Remittance.Models.Configurations;

namespace Slimforge.Api.Momo.Remittance.Brokers.MomoApis
{
    internal partial class MomoBroker : IMomoBroker
    {
        private readonly MomoConfigurations momoConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient, authApiClient;
        private readonly HttpClient httpClient, authHttpClient;

        public MomoBroker(MomoConfigurations momoConfigurations)
        {
            this.momoConfigurations = momoConfigurations;
            this.httpClient = SetupHttpClient();
            this.apiClient = SetupApiClient();
            // Auth specific endpoint initiliazation: dont ask me why Momo APIs suck!
            this.authHttpClient = SetupAuthHttpClient();
            this.authApiClient = SetupAuthClient();
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
            await this.apiClient.GetContentAsync<T>(relativeUrl);

        private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PostContentAsync(relativeUrl, content); 

        private async ValueTask<T> PostAsyncForAuthentication <T>(string relativeUrl, T content) =>
            await this.authApiClient.PostContentAsync(relativeUrl,content);

        private async ValueTask<TResult> PostAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        {
            return await this.apiClient.PostContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);
        }

        private async ValueTask<TResult> PostFormAsync<TRequest, TResult>(string relativeUrl, TRequest content)
            where TRequest : class
        {
            return await this.apiClient.PostFormAsync<TRequest, TResult>(
                relativeUrl,
                content);
        }

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PutContentAsync(relativeUrl, content);

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
            await this.apiClient.DeleteContentAsync<T>(relativeUrl);

        private HttpClient SetupHttpClient()
        {
            var httpClient =  new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.momoConfigurations.BaseUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: this.momoConfigurations.AccessToken);

            httpClient.DefaultRequestHeaders.Add(
                name: "Ocp-Apim-Subscription-Key",
                value: this.momoConfigurations.SubscriptionKey);

            httpClient.DefaultRequestHeaders.Add (
                name: "X-Target-Environment", 
                value: this.momoConfigurations.TargetEnvironment);
                        
            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);


        private HttpClient SetupAuthHttpClient()
        {
            var httpClient =  new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.momoConfigurations.BaseUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: this.momoConfigurations.AccessToken);

            httpClient.DefaultRequestHeaders.Add(
                name: "Ocp-Apim-Subscription-Key",
                value: this.momoConfigurations.SubscriptionKey);


            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    scheme: "Basic", 
                    parameter: Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{this.momoConfigurations.ApiUser}:{this.momoConfigurations.ApiKey}")));

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupAuthClient() =>
            new RESTFulApiFactoryClient(this.authHttpClient);
    }
}
