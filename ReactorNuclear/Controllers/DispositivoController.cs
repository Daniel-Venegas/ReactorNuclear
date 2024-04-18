using Microsoft.AspNetCore.Mvc;
using ReactorNuclear.Model;
using ReactorNuclear.Services;

namespace ReactorNuclear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispService _dispService;

        public DispositivoController (IDispService dispService)
        {
            _dispService = dispService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dispositivo>>> GetAllDisp()
        {
            return Ok(await _dispService.GetAllDisp());
        }

        [HttpGet("{IdDispositivo}")]
        public async Task<ActionResult<Dispositivo>> GetDispo(int IdDispositivo)
        {
            var dispositivo = await _dispService.GetDispo(IdDispositivo);
            if(dispositivo == null)
            {
                return NotFound("Registro no encontrado");
            }
            return Ok(dispositivo);
        }
        [HttpPost]
        public async Task<ActionResult<Dispositivo>> CreateDispo([FromBody]Dispositivo dispositivo)
        {
            if (dispositivo == null)
            {
                return BadRequest("El objeto Dispositivo es nulo");
            }
            var newDispositivo = await _dispService.CreateDispo(dispositivo.Dispo);
            return Ok(newDispositivo);
        }

        [HttpPut("{IdDispositivo}")]
        public async Task<ActionResult<Dispositivo>> UpdateDispo(int IdDispositivo, [FromBody] Dispositivo UpdateDispositivo)
        {
            if(UpdateDispositivo == null || IdDispositivo <=0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Dispositivo");
            }
            var updatedDispositivo = await _dispService.UpdateDispo(IdDispositivo, UpdateDispositivo.Dispo);
            return Ok(updatedDispositivo);
        }

        [HttpDelete("{IdDispositivo}")]
        public async Task<ActionResult<Dispositivo>> DeleteDispo(int IdDispositivo)
        {
            if (IdDispositivo <= 0)
            {
                return BadRequest("IdDispositivo invalido para eliminar");
            }
            var deletedDispositivo = await _dispService.DeleteDispo(IdDispositivo);
            return Ok(deletedDispositivo);
        }
    }
}
