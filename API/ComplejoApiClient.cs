using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class ComplejoApiClient : BaseApiClient
    {
        // --- COMPLEJOS ---

        public static async Task<List<ComplejoDTO>?> ObtenerTodosAsync()
        {
            return await GetAsync<List<ComplejoDTO>>("complejos");
        }

        public static async Task<ComplejoDTO?> ObtenerPorIdAsync(int id)
        {
            return await GetAsync<ComplejoDTO>($"complejos/{id}");
        }

        //CREAR ENDPOINT PARA OBTENER COMPLEJOS POR DUEÑO
        public static async Task<List<ComplejoDTO>?> ObtenerPorDuenoAsync(int idDueno)
        {
            return await GetAsync<List<ComplejoDTO>>($"complejos/dueno/{idDueno}");
        }

        public static async Task<ComplejoDTO?> CrearComplejoAsync(ComplejoCrearDTO dto)
        {
            return await PostAsync<ComplejoCrearDTO, ComplejoDTO>("complejos", dto);
        }

        public static async Task ActualizarComplejoAsync(ComplejoDTO dto)
        {
            await PutAsync("complejos", dto);
        }

        public static async Task EliminarComplejoAsync(int id)
        {
            await DeleteAsync($"complejos/{id}");
        }

        // --- HORARIOS ---

        public static async Task<List<HorarioDTO>?> ObtenerHorariosAsync(int idComplejo)
        {
            return await GetAsync<List<HorarioDTO>>($"complejos/{idComplejo}/horarios");
        }

        public static async Task<HorarioDTO?> ObtenerHorarioPorDiaAsync(int idComplejo, int numDia)
        {
            return await GetAsync<HorarioDTO>($"complejos/{idComplejo}/horarios/{numDia}");
        }

        public static async Task<HorarioDTO?> CrearHorarioAsync(int idComplejo, HorarioCrearDTO dto)
        {
            return await PostAsync<HorarioCrearDTO, HorarioDTO>($"complejos/{idComplejo}/horarios", dto);
        }

        public static async Task ActualizarHorarioAsync(int idComplejo, int numDia, HorarioEditarDTO dto)
        {
            await PutAsync($"complejos/{idComplejo}/horarios/{numDia}", dto);
        }

        public static async Task EliminarHorarioAsync(int idComplejo, int numDia)
        {
            await DeleteAsync($"complejos/{idComplejo}/horarios/{numDia}");
        }

        // --- CANCHAS ---

        public static async Task<List<CanchaDTO>?> ObtenerCanchasAsync(int idComplejo)
        {
            return await GetAsync<List<CanchaDTO>>($"complejos/{idComplejo}/canchas");
        }

        public static async Task<CanchaDTO?> ObtenerCanchaPorNroAsync(int idComplejo, int nro)
        {
            return await GetAsync<CanchaDTO>($"complejos/{idComplejo}/canchas/{nro}");
        }

        public static async Task<CanchaDTO?> CrearCanchaAsync(int idComplejo, CanchaCrearDTO dto)
        {
            return await PostAsync<CanchaCrearDTO, CanchaDTO>($"complejos/{idComplejo}/canchas", dto);
        }

        public static async Task ActualizarCanchaAsync(int idComplejo, int nro, CanchaCrearDTO dto)
        {
            await PutAsync($"complejos/{idComplejo}/canchas/{nro}", dto);
        }

        public static async Task EliminarCanchaAsync(int idComplejo, int nro)
        {
            await DeleteAsync($"complejos/{idComplejo}/canchas/{nro}");
        }

        // --- PRECIOS ---

        public static async Task<List<PrecioDTO>?> ObtenerPreciosAsync(int idComplejo, int nroCancha)
        {
            return await GetAsync<List<PrecioDTO>>($"complejos/{idComplejo}/canchas/{nroCancha}/precios");
        }

        public static async Task<PrecioDTO?> ObtenerPrecioPorFechaAsync(int idComplejo, int nroCancha, DateOnly fechaDesde)
        {
            string fechaFormateada = fechaDesde.ToString("yyyy-MM-dd");
            return await GetAsync<PrecioDTO>($"complejos/{idComplejo}/canchas/{nroCancha}/precios/{fechaFormateada}");
        }

        public static async Task<PrecioDTO?> CrearPrecioAsync(int idComplejo, int nroCancha, PrecioCrearDTO dto)
        {
            return await PostAsync<PrecioCrearDTO, PrecioDTO>($"complejos/{idComplejo}/canchas/{nroCancha}/precios", dto);
        }
    }
}