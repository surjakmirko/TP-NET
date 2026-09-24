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

    }
}
