using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReactorNuclear.Model;
using ReactorNuclear.Services;

namespace ReactorNuclear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVariableController : ControllerBase
    {
        private readonly ITipoVService _tipoVService;

        public TipoVariableController (ITipoVService tipoVService)
        {
            _tipoVService = tipoVService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoVariable>>> GetAllVariable()
        {
            return Ok(await _tipoVService.GetAllVariable());
        }

        [HttpGet("{IdTipoVariable}")]
        public async Task<ActionResult<TipoVariable>> GetTipoV(int IdTipoVariable)
        {
            var tipoDispositivo = await _tipoVService.GetTipoV(IdTipoVariable);
            if (tipoDispositivo == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(tipoDispositivo);
        }

        [HttpPost]
        public async Task<ActionResult<TipoVariable>> CreateTipoV([FromBody] TipoVariable tipoVariable)
        {
            if (tipoVariable == null)
            {
                return BadRequest("el objeto TipoVariable es nulo");
            }
            var newTipoVariable = await _tipoVService.CreateTipoV(tipoVariable.Variable);
            return Ok(newTipoVariable);
        }

        [HttpPut("{IdTipoVariable}")]
        public async Task<ActionResult<TipoVariable>> UpdateTipoV(int IdTipoVariable, [FromBody] TipoVariable updateTipoVariable)
        {
            if (updateTipoVariable == null || IdTipoVariable <=0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar TipoVariable");
            }
            var updatedTipoVariable = await _tipoVService.UpdateTipoV(IdTipoVariable, updateTipoVariable.Variable);
            return Ok(updatedTipoVariable);
        }
        
        [HttpDelete("{IdTipoVariable}")]
        public async Task <ActionResult<TipoVariable>> DeleteTipoV(int IdTipoVariable)
        {
            if (IdTipoVariable <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var deletedTipoVariable = await _tipoVService.DeleteTipoV(IdTipoVariable);
            return Ok(deletedTipoVariable);
        }

    }
}
