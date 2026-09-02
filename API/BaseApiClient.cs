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
            // Configuración de URL base y tipo de contenido aceptado (JSON)
            string baseUrl = GetBaseUrlFromConfig();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static string GetBaseUrlFromConfig()
        {
            //try
            //{
            //    // Variable de entorno personalizada si existe
            //    string? envUrl = Environment.GetEnvironmentVariable("TPI_API_BASE_URL");
            //    if (!string.IsNullOrEmpty(envUrl))
            //    {
            //        return envUrl;
            //    }

            //    // Si se ejecuta sobre emulador Android, se asigna el loopback de Android
            //    string runtimeInfo = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier;
            //    if (runtimeInfo.StartsWith("android"))
            //    {
            //        return "http://10.0.2.2:5183/";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine($"[DEBUG] Error leyendo configuración de red: {ex.Message}");
            //}

            // URL por defecto para entornos locales en Windows (WinForms)
            return "http://localhost:5183/";
        }

        protected static void HandleResponseError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error en la petición a la API. Código de estado: {response.StatusCode}");
            }
        }
    }
}
