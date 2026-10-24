using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Blazor.WebAssembly.Servicios;

namespace Blazor.WebAssembly.Servicios
{
    public class TipoCanchaApiClient : BlazorApiClient
    {
        public TipoCanchaApiClient(HttpClient http) : base(http) { }

        public async Task<List<TipoCanchaDTO>?> ObtenerTodosAsync()
        {
            return await GetAsync<List<TipoCanchaDTO>>("tipos-cancha");
        }
    }
}