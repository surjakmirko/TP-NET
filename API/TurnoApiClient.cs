using DTOs;
namespace API
{
    public class TurnoApiClient : BaseApiClient
    {
        public static async Task<TurnoDTO> CrearTurnoAsync(TurnoCrearDTO dto)
        {
            return await PostAsync<TurnoCrearDTO, TurnoDTO>("turnos", dto);
        }
        public static async Task<List<TurnoDTO>?> ObtenerTurnosCliente(int idCliente)
        {
            return await GetAsync<List<TurnoDTO>>($"turnos/cliente/{idCliente}");
        }
        public static async Task CancelarTurnoAsync(int id, string? motivoCancelacion = null)
        {
            await PutAsync($"turnos/{id}/cancelar", new CancelarTurnoDTO { MotivoCancelacion = motivoCancelacion });
        }

        public static async Task<TurnoDTO> CrearTurnoEncargadoAsync(TurnoCrearEncargadoDTO dto, string? token = null)
        {
            return await PostAsync<TurnoCrearEncargadoDTO, TurnoDTO>("turnos/encargado", dto, token);
        }
    }
}
