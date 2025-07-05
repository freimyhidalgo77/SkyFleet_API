using Microsoft.AspNetCore.Mvc;
using SkyFleet.Abstraccion;
using SkyFleet.Data.Context;
using SkyFleet.Data.Model;
using SkyFleet.Domain.DTO;
using SkyFleet.Services;

namespace SkyFleet_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RutaController(IRutasService rutasService) : ControllerBase
    {

        private readonly SkyFleetContext _context;

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutaDTO>>> GetRuta()
        {
            return await rutasService.Listar(t => true);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RutaDTO>> GetRutas(int id)
        {
            return await rutasService.Buscar(id);
        }

   
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuta(int id, RutaDTO rutaDTO)
        {
            if (id != rutaDTO.RutaId)
            {
                return BadRequest();
            }

            // Actualizar la retencion
            await rutasService.Guardar(rutaDTO);
            return NoContent();
        }

     
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rutas>> PostRuta(RutaDTO rutaDTO)
        {
            await rutasService.Guardar(rutaDTO);
            return CreatedAtAction("GetRuta", new { id = rutaDTO.RutaId }, rutaDTO);

        }

        // DELETE: api/TipoVuelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuta(int id)
        {
            await rutasService.Eliminar(id);
            return NoContent();
        }

    }
}

