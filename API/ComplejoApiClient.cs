using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class ComplejoApiClient : BaseApiClient
    {
        public static async Task CrearComplejoAsync(ComplejoDTO dto)
        {
            await PostAsync("complejos", dto);
        }
        public static async Task<ComplejoDTO?> ObtenerPorIdAsync(int id)
        {
            return await GetAsync<ComplejoDTO>($"complejos/{id}");
        }
        public static async Task ActualizarComplejoAsync(ComplejoDTO dto)
        {
            await PutAsync("complejos", dto);
        }
        public static async Task<List<ComplejoDTO>?> ObtenerPorDuenoAsync(int idDueno)
        {
            return await GetAsync<List<ComplejoDTO>>($"complejos/dueno/{idDueno}");
        }
    }
}