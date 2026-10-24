using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Blazor.WebAssembly.Servicios;

namespace Blazor.WebAssembly.Servicios
{
    public class CanchaApiClient : BlazorApiClient
    {
        public CanchaApiClient(HttpClient http) : base(http) { }

        public async Task<List<CanchaDTO>?> ObtenerPorComplejoIdAsync(int idComplejo)
        {
            return await GetAsync<List<CanchaDTO>>($"complejos/{idComplejo}/canchas");
        }

        public async Task<CanchaDTO?> ObtenerPorNroAsync(int idComplejo, int nro)
        {
            return await GetAsync<CanchaDTO>($"complejos/{idComplejo}/canchas/{nro}");
        }

        public async Task<CanchaDTO?> CrearAsync(int idComplejo, CanchaCrearDTO dto)
        {
            return await PostAsync<CanchaCrearDTO, CanchaDTO>($"complejos/{idComplejo}/canchas", dto);
        }

        public async Task ActualizarAsync(int idComplejo, int nro, CanchaCrearDTO dto)
        {
            await PutAsync($"complejos/{idComplejo}/canchas/{nro}", dto);
        }

        public async Task EliminarAsync(int idComplejo, int nro)
        {
            await DeleteAsync($"complejos/{idComplejo}/canchas/{nro}");
        }
    }
}