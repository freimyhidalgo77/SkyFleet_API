using SkyFleet.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Abstraccion
{
    public interface ITipoVueloService
    {
        Task<bool> Guardar(TipoVueloDTO tipoVuelo);
        Task<bool> Eliminar(int tipoVueloId);
        Task<TipoVueloDTO> Buscar(int id);
        Task<List<TipoVueloDTO>> Listar(Expression<Func<TipoVueloDTO, bool>> criterio);
        Task<bool> TipoVueloExiste(int id, string descripcion);

    }
}
