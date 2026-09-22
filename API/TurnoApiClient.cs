using DTOs;
namespace API
{
    public class TurnoApiClient : BaseApiClient
    {
        public static async Task<TurnoDTO> CrearTurnoAsync(TurnoCrearDTO dto)
        {
            return await PostAsync<TurnoCrearDTO, TurnoDTO>("turnos", dto);
        }
    }
}
