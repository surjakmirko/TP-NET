using Modelo.Dominio;


namespace Data
{
    public interface IPersonaFisica
    {
        Task AddAsync(PersonaFisica personafisica);
        Task<bool> DeleteAsync(string dni);
        Task<PersonaFisica?> GetAsync(string dni);
        Task<IEnumerable<PersonaFisica>> GetAllAsync();
        Task<bool> UpdateAsync(PersonaFisica personafisica);
        Task<bool> DniExistsAsync(string dni);
    }
}
