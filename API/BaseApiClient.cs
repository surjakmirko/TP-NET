using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API
{
    public abstract class BaseApiClient
    {
        protected static async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            await ConfigureHttpClientAsync(client);
            return client;
        }

        protected static async Task ConfigureHttpClientAsync(HttpClient client)
        {
            string baseUrl = GetBaseUrlFromConfig();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static string GetBaseUrlFromConfig()
        {
            return "http://localhost:5262/";
        }

        protected static async Task<T?> GetAsync<T>(string endpoint)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync(endpoint);
            HandleResponseError(response);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        protected static async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data);
            HandleResponseError(response);
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        protected static async Task PostAsync<TRequest>(string endpoint, TRequest data)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data);
            HandleResponseError(response);
        }

        protected static async Task DeleteAsync(string endpoint)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync(endpoint);
            HandleResponseError(response);
        }

        protected static void HandleResponseError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string errorContent = response.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Error en la API ({response.StatusCode}): {errorContent}");
            }
        }
        protected static async Task PutAsync<TRequest>(string endpoint, TRequest data)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync(endpoint, data);
            HandleResponseError(response);
        }
    }
}