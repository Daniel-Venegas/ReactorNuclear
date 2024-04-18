using Microsoft.AspNetCore.Mvc;
using ReactorNuclear.Model;
using ReactorNuclear.Services;

namespace ReactorNuclear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleDControler : ControllerBase
    {
        private readonly IDetalleDService _detalleDService;

        public DetalleDControler (IDetalleDService detalleDService)
        {
            _detalleDService = detalleDService;
        }


        [HttpGet]
        public async Task<ActionResult<List<DetalleDispositivo>>> GetAll()
        {
            return Ok(await _detalleDService.GetAll());
        }


        [HttpGet("{IdDetalleDispositivo}")]
        public async Task<ActionResult<DetalleDispositivo>> GetDetalleD(int IdDetalleDispositivo)
        {
            var DetalleD = await _detalleDService.GetDetalleD(IdDetalleDispositivo);
            if(DetalleD == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(DetalleD);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleDispositivo>> CreateDetalleD([FromBody] DetalleDispositivo detalleDispositivo)
        {
            if (detalleDispositivo == null)
            {
                return BadRequest("El objeto DetalleDispositivo es nulo.");
            }

            var newDetalleD = await _detalleDService.CreateDetalleD(detalleDispositivo.IdDispositivo, detalleDispositivo.IdCaracteristicas, detalleDispositivo.Caracteristicas);
            return Ok(newDetalleD);
        }

        [HttpPut("{IdDetalleDispositivo}")]
        public async Task<ActionResult<DetalleDispositivo>> UpdateDetalleD(int IdDetalleDispositivo, [FromBody] DetalleDispositivo updatedDetalleDispositivo)
        {
            if (updatedDetalleDispositivo == null || IdDetalleDispositivo <= 0)
            {
                return BadRequest("Datos de entrada inválidos para actualizar DetalleDispositivo.");
            }

            var updatedDetalleD = await _detalleDService.UpdateDetalleD(IdDetalleDispositivo, updatedDetalleDispositivo.IdDispositivo, updatedDetalleDispositivo.IdCaracteristicas, updatedDetalleDispositivo.Caracteristicas);
            return Ok(updatedDetalleD);
        }

        [HttpDelete("{IdDetalleDispositivo}")]
        public async Task<ActionResult<DetalleDispositivo>> DeleteDetalleD(int IdDetalleDispositivo)
        {
            if (IdDetalleDispositivo <= 0)
            {
                return BadRequest("IdDetalleDispositivo inválido para eliminar.");
            }

            var deletedDetalleD = await _detalleDService.DeleteDetalleD(IdDetalleDispositivo);
            return Ok(deletedDetalleD);
        }

    }
}
