using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class TipoCanchaApiClient : BaseApiClient
    {
        public static async Task<List<TipoCanchaDTO>?> ObtenerTodosAsync()
        {
            return await GetAsync<List<TipoCanchaDTO>>("tipocancha");
        }
    }
}