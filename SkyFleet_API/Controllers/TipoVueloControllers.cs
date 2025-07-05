using Microsoft.AspNetCore.Mvc;
using SkyFleet.Data.Context;
using SkyFleet.Domain.DTO;
using SkyFleet.Abstraccion;
using SkyFleet.Data.Model;


namespace SkyFleet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoVueloControllers(ITipoVueloService tipoVueloService) : ControllerBase
    {

        private readonly SkyFleetContext _context;

        // GET: api/tipoVuelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVueloDTO>>> GetTipoVuelo()
        {
            return await tipoVueloService.Listar(t => true);
        }

        // GET: api/TipoVuelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVueloDTO>> GetTiposVuelos(int id)
        {
            return await tipoVueloService.Buscar(id);
        }

        // PUT: api/TiposVuelos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVuelo(int id, TipoVueloDTO tipoVueloDTO)
        {
            if (id != tipoVueloDTO.TipoVueloId)
            {
                return BadRequest();
            }

            // Actualizar la retencion
            await tipoVueloService.Guardar(tipoVueloDTO);
            return NoContent();
        }

        // POST: api/TipoVuelo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVuelo>> PostTipoVuelo(TipoVueloDTO tipoVueloDTO)
        {
            await tipoVueloService.Guardar(tipoVueloDTO);
            return CreatedAtAction("GetTipoVuelo", new { id = tipoVueloDTO.TipoVueloId}, tipoVueloDTO);

        }

        // DELETE: api/TipoVuelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVuelo(int id)
        {
            await tipoVueloService.Eliminar(id);
            return NoContent();
        }

        private bool TipoVueloExists(int id)
        {
            return _context.tipoVuelo.Any(e => e.tipoVueloId == id);
        }

    }
}

