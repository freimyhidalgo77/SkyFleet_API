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
    public class RutaSercvice(IDbContextFactory<SkyFleetContext> DbFactory) : IRutasService
    {

        private async Task<bool> Existe(int rutaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.rutas.AnyAsync(e => e.RutaId == rutaId);
        }

        private async Task<bool> Insertar(RutaDTO rutaDto)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var rutas = new Rutas()
            {
                RutaId = rutaDto.RutaId,
                origen = rutaDto.origen,
                destino = rutaDto.destino,
                duracion = rutaDto.duracion,
                distancia = rutaDto.distancia,

            };
            context.rutas.Add(rutas);
            var save = await context.SaveChangesAsync() > 0;
            rutaDto.RutaId = rutaDto.RutaId;
            return save;
        }

        private async Task<bool> Modificar(RutaDTO rutaDto)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var ruta = new Rutas()
            {
                RutaId = rutaDto.RutaId,
                origen = rutaDto.origen,
                destino = rutaDto.destino,
                duracion = rutaDto.duracion,
                distancia = rutaDto.distancia,
            };
            context.Update(ruta);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(RutaDTO rutas)
        {
            if (!await Existe(rutas.RutaId))
            {
                return await Insertar(rutas);
            }
            else
            {
                return await Modificar(rutas);
            }
        }

        public async Task<bool> Eliminar(int rutaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.rutas
                .Where(e => e.RutaId == rutaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<RutaDTO> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var rutas = await context.rutas
                .Where(e => e.RutaId == id)
                .Select(c => new RutaDTO()
                {
                    RutaId = c.RutaId,
                    origen = c.origen,
                    destino = c.destino,
                    duracion = c.duracion,
                    distancia = c.distancia,

                }).FirstOrDefaultAsync();

            return rutas ?? new RutaDTO();
        }

        public async Task<List<RutaDTO>> Listar(Expression<Func<RutaDTO, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.rutas
                .Select(c => new RutaDTO()
                {
                    RutaId = c.RutaId,
                    origen = c.origen,
                    destino = c.destino,
                    duracion = c.duracion,
                    distancia = c.distancia,

                })
                .Where(criterio)
                .ToListAsync();
        }

    }

}

