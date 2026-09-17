using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Client
{
    public interface IAutenticacionService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetTokenAsync();

        // Evento para notificar a la UI cuando el usuario entra o sale
        event Action<bool>? AuthenticationStateChanged;
    }
}
