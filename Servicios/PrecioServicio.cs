using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<PrecioDTO> AddAsync(PrecioDTO dto)
        {
            Precio precio = new Precio(dto.PrecioBase, dto.PrecioAdicional, dto.PrecioSena, dto.FechaDesde, dto.ComplejoId, dto.CanchaNro);

            await precioRepositorio.AddAsync(precio);
            dto.FechaDesde = precio.FechaDesde;
            return dto;
        }
        public async Task<bool> DeleteAsync(DateOnly FechaDesde)
        {
            return await precioRepositorio.DeleteAsync(FechaDesde);
        }
        public async Task<PrecioDTO?> GetAsync(DateOnly FechaDesde)
        {
            Precio? precio = await precioRepositorio.GetAsync(FechaDesde);

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
        public async Task<IEnumerable<PrecioDTO>> GetAllAsync()
        {
            var precios = await precioRepositorio.GetAllAsync();

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
        public async Task<bool> UpdateAsync(PrecioDTO dto)
        {
            if (await precioRepositorio.FechaDesdeExistsAsync(dto.FechaDesde))
            {
                throw new ArgumentException($"Ya existe otro precio con la fecha '{dto.FechaDesde}'.");
            }


            Precio precio = new Precio(dto.PrecioBase, dto.PrecioAdicional, dto.PrecioSena, dto.FechaDesde, dto.ComplejoId, dto.CanchaNro);
            return await precioRepositorio.UpdateAsync(precio);
        }
    }
}
