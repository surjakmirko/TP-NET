using DTOs;
using Data;
using Modelo.Dominio;

namespace Servicios
{
    public class PrecioServicio : IPrecioServicio
    {
        private readonly IPrecioRepositorio precioRepositorio;
        public PrecioServicio(IPrecioRepositorio precioRepositorio)
        {
            this.precioRepositorio = precioRepositorio;
        }
        public async Task<PrecioDTO> AddAsync(PrecioCrearDTO dto, int complejoId, int nroCancha)
        {
            Precio precio = new Precio(dto.PrecioBase, dto.PrecioAdicional, dto.PrecioSena, dto.FechaDesde, complejoId, nroCancha);

            await precioRepositorio.AddAsync(precio);

            return new PrecioDTO
            {
                ComplejoId = complejoId,
                CanchaNro = nroCancha,
                PrecioBase = dto.PrecioBase,
                PrecioAdicional = dto.PrecioAdicional,
                PrecioSena = dto.PrecioSena,
                FechaDesde = dto.FechaDesde,
            };
        }
        
        public async Task<PrecioDTO?> GetAsync(int complejoId,int nro, DateOnly FechaDesde)
        {
            Precio? precio = await precioRepositorio.GetAsync(complejoId, nro,FechaDesde);

            if (precio == null)
                return null;

            return new PrecioDTO
            {
                PrecioBase = precio.PrecioBase,
                PrecioAdicional = precio.PrecioAdicional,
                PrecioSena = precio.PrecioSena,
                FechaDesde = precio.FechaDesde,
                ComplejoId = precio.ComplejoId,
                CanchaNro = precio.CanchaNro
            };  
        }
        public async Task<IEnumerable<PrecioDTO>> GetAllAsync(int complejoId,int nro)
        {
            var precios = await precioRepositorio.GetAllAsync(complejoId,nro);

            return precios.Select(precio => new PrecioDTO
            {
                PrecioBase = precio.PrecioBase,
                PrecioAdicional = precio.PrecioAdicional,
                PrecioSena = precio.PrecioSena,
                FechaDesde = precio.FechaDesde,
                ComplejoId = precio.ComplejoId,
                CanchaNro = precio.CanchaNro
            }).ToList();
        }
       
    }
}
