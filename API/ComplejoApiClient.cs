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
    }
}