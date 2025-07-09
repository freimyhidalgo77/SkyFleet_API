using SkyFleet.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Abstraccion
{
    public interface IAeronavesService
    {
        Task<bool> Guardar(AeronaveDTO aeronave);
        Task<bool> Eliminar(int aeronaveId);
        Task<AeronaveDTO> Buscar(int id);
        Task<List<AeronaveDTO>> Listar(Expression<Func<AeronaveDTO, bool>> criterio);
        Task<bool> AeronaveExiste(int id);
    }
}
