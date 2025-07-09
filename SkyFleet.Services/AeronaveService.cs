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
    public class AeronaveService(IDbContextFactory<SkyFleetContext> DbFactory) : IAeronavesService
    {

        public async Task<bool> AeronaveExiste(int Id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.aeronaves.AnyAsync(e => e.AeronaveId == Id);
        }

        private async Task<bool> Insertar(AeronaveDTO aeronaveDto)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var aeronaves = new Aeronaves()
            {
                AeronaveId = aeronaveDto.AeronaveId,
                estadoId = aeronaveDto.estadoId,
                ModeloAvion = aeronaveDto.ModeloAvion,
                DescripcionCategoria = aeronaveDto.DescripcionCategoria,
                Registracion = aeronaveDto.Registracion,
                CostoXHora = aeronaveDto.CostoXHora,
                DescripcionAeronave = aeronaveDto.DescripcionAeronave,
                VelocidadMaxima = aeronaveDto.VelocidadMaxima,
                DescripcionMotor = aeronaveDto.DescripcionMotor,
                CapacidadCombustible = aeronaveDto.CapacidadCombustible,
                ConsumoXHora = aeronaveDto.ConsumoXHora,
                Peso = aeronaveDto.Peso,
                Rango = aeronaveDto.Rango,
                CapacidadPasajeros = aeronaveDto.CapacidadPasajeros,
                AltitudMaxima = aeronaveDto.AltitudMaxima,
                Licencia = aeronaveDto.Licencia

            };
            context.aeronaves.Add(aeronaves);
            var save = await context.SaveChangesAsync() > 0;
            aeronaveDto.AeronaveId = aeronaveDto.AeronaveId;
            return save;
        }

        private async Task<bool> Modificar(AeronaveDTO aeronaveDto)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var aeronave = new Aeronaves()
            {
                AeronaveId = aeronaveDto.AeronaveId,
                estadoId = aeronaveDto.estadoId,
                ModeloAvion = aeronaveDto.ModeloAvion,
                DescripcionCategoria = aeronaveDto.DescripcionCategoria,
                Registracion = aeronaveDto.Registracion,
                CostoXHora = aeronaveDto.CostoXHora,
                DescripcionAeronave = aeronaveDto.DescripcionAeronave,
                VelocidadMaxima = aeronaveDto.VelocidadMaxima,
                DescripcionMotor = aeronaveDto.DescripcionMotor,
                CapacidadCombustible = aeronaveDto.CapacidadCombustible,
                ConsumoXHora = aeronaveDto.ConsumoXHora,
                Peso = aeronaveDto.Peso,
                Rango = aeronaveDto.Rango,
                CapacidadPasajeros = aeronaveDto.CapacidadPasajeros,
                AltitudMaxima = aeronaveDto.AltitudMaxima,
                Licencia = aeronaveDto.Licencia
            };
            context.Update(aeronave);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(AeronaveDTO aeronaves)
        {
            if (!await AeronaveExiste(aeronaves.AeronaveId))
            {
                return await Insertar(aeronaves);
            }
            else
            {
                return await Modificar(aeronaves);
            }
        }

        public async Task<bool> Eliminar(int aeronaveId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.aeronaves
                .Where(e => e.AeronaveId == aeronaveId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<AeronaveDTO> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var aeronaves = await context.aeronaves
                .Where(e => e.AeronaveId == id)
                .Select(c => new AeronaveDTO()
                {
                    AeronaveId = c.AeronaveId,
                    estadoId = c.estadoId,
                    ModeloAvion = c.ModeloAvion,
                    DescripcionCategoria = c.DescripcionCategoria,
                    Registracion = c.Registracion,
                    CostoXHora = c.CostoXHora,
                    DescripcionAeronave = c.DescripcionAeronave,
                    VelocidadMaxima = c.VelocidadMaxima,
                    DescripcionMotor = c.DescripcionMotor,
                    CapacidadCombustible = c.CapacidadCombustible,
                    ConsumoXHora = c.ConsumoXHora,
                    Peso = c.Peso,
                    Rango = c.Rango,
                    CapacidadPasajeros = c.CapacidadPasajeros,
                    AltitudMaxima = c.AltitudMaxima,
                    Licencia = c.Licencia,

                }).FirstOrDefaultAsync();

            return aeronaves ?? new AeronaveDTO();
        }

        public async Task<List<AeronaveDTO>> Listar(Expression<Func<AeronaveDTO, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.aeronaves
                .Select(c => new AeronaveDTO()
                {
                    AeronaveId = c.AeronaveId,
                    estadoId = c.estadoId,
                    ModeloAvion = c.ModeloAvion,
                    DescripcionCategoria = c.DescripcionCategoria,
                    Registracion = c.Registracion,
                    CostoXHora = c.CostoXHora,
                    DescripcionAeronave = c.DescripcionAeronave,
                    VelocidadMaxima = c.VelocidadMaxima,
                    DescripcionMotor = c.DescripcionMotor,
                    CapacidadCombustible = c.CapacidadCombustible,
                    ConsumoXHora = c.ConsumoXHora,
                    Peso = c.Peso,
                    Rango = c.Rango,
                    CapacidadPasajeros = c.CapacidadPasajeros,
                    AltitudMaxima = c.AltitudMaxima,
                    Licencia = c.Licencia,

                })
                .Where(criterio)
                .ToListAsync();
        }

    }
}
