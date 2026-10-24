using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.WebAssembly.Servicios
{
    public abstract class BlazorApiClient
    {
        protected readonly HttpClient Http;

        protected BlazorApiClient(HttpClient http)
        {
            Http = http;
        }

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await Http.GetAsync(endpoint);
            await HandleResponseError(response);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var response = await Http.PostAsJsonAsync(endpoint, data);
            await HandleResponseError(response);
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        protected async Task PostAsync<TRequest>(string endpoint, TRequest data)
        {
            var response = await Http.PostAsJsonAsync(endpoint, data);
            await HandleResponseError(response);
        }

        protected async Task PutAsync<TRequest>(string endpoint, TRequest data)
        {
            var response = await Http.PutAsJsonAsync(endpoint, data);
            await HandleResponseError(response);
        }

        protected async Task DeleteAsync(string endpoint)
        {
            var response = await Http.DeleteAsync(endpoint);
            await HandleResponseError(response);
        }

        private static async Task HandleResponseError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error en la API ({response.StatusCode}): {errorContent}");
            }
        }
    }
}