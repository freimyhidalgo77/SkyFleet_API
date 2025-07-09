using Microsoft.AspNetCore.Mvc;
using SkyFleet.Abstraccion;
using SkyFleet.Data.Context;
using SkyFleet.Data.Model;
using SkyFleet.Domain.DTO;

namespace SkyFleet_API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AeronaveController(IAeronavesService aeronavesService) : ControllerBase
        {

            private readonly SkyFleetContext _context;


            [HttpGet]
            public async Task<ActionResult<IEnumerable<AeronaveDTO>>> GetAeronave()
            {
                return await aeronavesService.Listar(t => true);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<AeronaveDTO>> GetAeronaves(int id)
            {
                return await aeronavesService.Buscar(id);
            }


            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAeronave(int id, AeronaveDTO aeronaveDTO)
            {
                if (id != aeronaveDTO.AeronaveId)
                {
                    return BadRequest();
                }

                // Actualizar la retencion
                await aeronavesService.Guardar(aeronaveDTO);
                return NoContent();
            }


            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Aeronaves>> PostAeronave(AeronaveDTO aeronaveDTO)
            {
                await aeronavesService.Guardar(aeronaveDTO);
                return CreatedAtAction("GetAeronave", new { id = aeronaveDTO.AeronaveId }, aeronaveDTO);

            }

            // DELETE: api/TipoVuelo/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAeronave(int id)
            {
                await aeronavesService.Eliminar(id);
                return NoContent();
            }

        }
    }
