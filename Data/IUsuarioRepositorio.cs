using Modelo.Dominio;

namespace Data
{
    public interface IUsuarioRepositorio
    {
        Task AddAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<Usuario?> GetAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<bool> UpdateAsync(Usuario cliente);
        Task<bool> EmailExistsAsync(string email);
        //Task<IEnumerable<Cliente>> GetByCriteriaAsync(ClienteCriteria criteria);
    }
}