using SkyFleet.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Abstraccion
{
    public interface IRutasService
    {
        Task<bool> Guardar(RutaDTO ruta);
        Task<bool> Eliminar(int rutaId);
        Task<RutaDTO> Buscar(int id);
        Task<List<RutaDTO>> Listar(Expression<Func<RutaDTO, bool>> criterio);

    }
}
