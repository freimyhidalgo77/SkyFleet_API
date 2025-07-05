using Microsoft.EntityFrameworkCore;
using SkyFleet.Abstraccion;
using SkyFleet.Data.Context;
using SkyFleet.Data.Model;
using SkyFleet.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Services
{
    public class TipoVueloService(IDbContextFactory<SkyFleetContext> DbFactory) : ITipoVueloService
    {
        private async Task<bool> Existe(int retencionId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.tipoVuelo.AnyAsync(e => e.tipoVueloId == retencionId);
        }

        private async Task<bool> Insertar(TipoVueloDTO tipoVueloDTO)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var tipoVuelo = new TipoVuelo()
            {
                tipoVueloId = tipoVueloDTO.TipoVueloId,
                nombreVuelo = tipoVueloDTO.nombreVuelo,
                descripcionTipoVuelo = tipoVueloDTO.descripcionTipoVuelo,

            };
            context.tipoVuelo.Add(tipoVuelo);
            var save = await context.SaveChangesAsync() > 0;
            tipoVueloDTO.TipoVueloId = tipoVueloDTO.TipoVueloId;
            return save;
        }

        private async Task<bool> Modificar(TipoVueloDTO tipoVueloDTO)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var tipoVuelo = new TipoVuelo()
            {
                tipoVueloId = tipoVueloDTO.TipoVueloId,
                nombreVuelo = tipoVueloDTO.nombreVuelo,
                descripcionTipoVuelo = tipoVueloDTO.descripcionTipoVuelo,

            };
            context.Update(tipoVuelo);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(TipoVueloDTO tipoVuelo)
        {
            if (!await Existe(tipoVuelo.TipoVueloId))
            {
                return await Insertar(tipoVuelo);
            }
            else
            {
                return await Modificar(tipoVuelo);
            }
        }

        public async Task<bool> Eliminar(int tipoVueloId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.tipoVuelo
                .Where(e => e.tipoVueloId == tipoVueloId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<TipoVueloDTO> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var tipoVuelo = await context.tipoVuelo
                .Where(e => e.tipoVueloId == id)
                .Select(c => new TipoVueloDTO()
                {
                    TipoVueloId = c.tipoVueloId,
                    nombreVuelo = c.nombreVuelo,
                    descripcionTipoVuelo = c.descripcionTipoVuelo,

                }).FirstOrDefaultAsync();

            return tipoVuelo ?? new TipoVueloDTO();
        }

        public async Task<List<TipoVueloDTO>> Listar(Expression<Func<TipoVueloDTO, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.tipoVuelo
                .Select(c => new TipoVueloDTO()
                {
                    TipoVueloId = c.tipoVueloId,
                    nombreVuelo = c.nombreVuelo,
                    descripcionTipoVuelo = c.descripcionTipoVuelo,

                })
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> TipoVueloExiste(int id, string nombreVuelo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.tipoVuelo
                .AnyAsync(e => e.tipoVueloId != id && e.nombreVuelo.ToLower().Equals(nombreVuelo.ToLower()));
        }


    }
}
