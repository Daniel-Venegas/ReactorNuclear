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
                return BadRequest("user not found");
            }
            return Ok(DetalleD);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleDispositivo>> CreateDetalleD([FromBody] DetalleDispositivo detalleDispositivo)
        {
            try
            {
                var newDetalleD = await _detalleDService.CreateDetalleD(detalleDispositivo.IdDispositivo, detalleDispositivo.IdCaracteristicas, detalleDispositivo.Caracteristicas);
                return Ok(newDetalleD);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creando DetalleDispositivo: {ex.Message}");
            }
        }

        [HttpPut("{IdDetalleDispositivo}")]
        public async Task<ActionResult<DetalleDispositivo>> UpdateDetalleD(int IdDetalleDispositivo, [FromBody] DetalleDispositivo updatedDetalleDispositivo)
        {
            try
            {
                var updatedDetalleD = await _detalleDService.UpdateDetalleD(IdDetalleDispositivo, updatedDetalleDispositivo.IdDispositivo, updatedDetalleDispositivo.IdCaracteristicas, updatedDetalleDispositivo.Caracteristicas);
                return Ok(updatedDetalleD);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error actualizando DetalleDispositivo: {ex.Message}");
            }
        }

        [HttpDelete("{IdDetalleDispositivo}")]
        public async Task<ActionResult<DetalleDispositivo>> DeleteDetalleD(int IdDetalleDispositivo)
        {
            try
            {
                var deletedDetalleD = await _detalleDService.DeleteDetalleD(IdDetalleDispositivo);
                return Ok(deletedDetalleD);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al borrar DetalleDispositivo: {ex.Message}");
            }
        }

    }
}
