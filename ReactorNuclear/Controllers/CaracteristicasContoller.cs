using Microsoft.AspNetCore.Mvc;
using ReactorNuclear.Model;
using ReactorNuclear.Services;

namespace ReactorNuclear.Controllers
{
    [Route("api[Controller]")]
    [ApiController]
    public class CaracteristicasController : ControllerBase
    {
        private readonly ICaracteristicasService _caracteristicasService;

        public CaracteristicasController(ICaracteristicasService caracteristicasService)
        {
            _caracteristicasService = caracteristicasService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CaracteristicasI>>> GetAllCarcat()
        {
            return Ok(await _caracteristicasService.GetAllCarcat());
        }
        [HttpGet("{IdCaracteristicas}")]

        public async Task<ActionResult<CaracteristicasI>> GetCaract(int IdCaracteristicas)
        {
            var Caracteristica = await _caracteristicasService.GetCaract(IdCaracteristicas);
            if (Caracteristica == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(Caracteristica);
        }

        [HttpPost]
        public async Task<ActionResult<CaracteristicasI>> CreateCaract([FromBody] CaracteristicasI caracteristicasI)
        {
            if (caracteristicasI == null)
            {
                return BadRequest("El objeto CaracteristicasI en nulo");
            }
            var newCaracteristica = await _caracteristicasService.CreateCaract(caracteristicasI.CaracteristicasRequired);
            return Ok(newCaracteristica);
        }

        [HttpPut("{IdCaracteristicas}")]
        public async Task<ActionResult<CaracteristicasI>> UpdateCaract(int IdCaracteristicas, [FromBody] CaracteristicasI Updatedcaracteristicas)
        {
            if (Updatedcaracteristicas == null || IdCaracteristicas <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar CaracteristicasI");
            }
            var UpdatedCaract = await _caracteristicasService.UpdateCaract(IdCaracteristicas, Updatedcaracteristicas.CaracteristicasRequired);
            return Ok(UpdatedCaract);
        }
        [HttpDelete("{IdCaracteristicas}")]
        public async Task<ActionResult<CaracteristicasI>> DeleteCaract(int IdCaracteristicas)
        {
            if (IdCaracteristicas <= 0)
            {
                return BadRequest("IdCaracteristicas invalido para eliminar");
            }
            var DeletedCarcact = await _caracteristicasService.DeleteCaract(IdCaracteristicas);
            return Ok(DeletedCarcact);
        }
    }


}
