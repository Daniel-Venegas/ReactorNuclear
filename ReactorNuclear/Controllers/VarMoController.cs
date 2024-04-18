using Microsoft.AspNetCore.Mvc;
using ReactorNuclear.Services;
using ReactorNuclear.Model;

namespace ReactorNuclear.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VarMoController : ControllerBase
    {

        private readonly IVarMoService _varMoService;
        public VarMoController(IVarMoService varMoService)
        {
            _varMoService = varMoService;
        }

        [HttpGet]
        public async Task<ActionResult<VariableMonitoreo>> GetAllVarMo()
        {
            return Ok(await _varMoService.GetAllVarMo());
        }

        [HttpGet("{IdVariableMonitoreo}")]
        public async Task<ActionResult<VariableMonitoreo>> GetVar(int IdVariableMonitoreo)
        {
            var variableMonitoreo = await _varMoService.GetVar(IdVariableMonitoreo);
            if (variableMonitoreo == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(variableMonitoreo);  
        }

        [HttpPost]
        public async Task<ActionResult<VariableMonitoreo>> CreateVarMo([FromBody] VariableMonitoreo variableMonitoreo)
        {
            if (variableMonitoreo == null)
            {
                return BadRequest("el Objeto VariableMonitoreo es nulo");
            }
            var newVariable = await _varMoService.CreateVarMo(variableMonitoreo.VarMonitoreo, variableMonitoreo.IdTipoVariable);
            return Ok(newVariable);
        }

        [HttpPut("{IdVariableMonitoreo}")]
        public async Task<ActionResult<VariableMonitoreo>> UpdateVarMo(int IdVariableMonitoreo, [FromBody] VariableMonitoreo updateVariableMonitoreo)
        {
            if(updateVariableMonitoreo == null || IdVariableMonitoreo >= 0 )
            {
                return BadRequest("Datos de entrada invalidos para actualizar VariableMonitoreo");
            }
            var updatedVariable = await _varMoService.UpdateVarMo(IdVariableMonitoreo, updateVariableMonitoreo.VarMonitoreo, updateVariableMonitoreo.IdTipoVariable);
            return Ok(updatedVariable);
        }

        [HttpDelete("{IdVariableMonitoreo}")]
        public async Task<ActionResult<VariableMonitoreo>> DeleteVariable(int IdVariableMonitoreo)
        {
            if (IdVariableMonitoreo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            
            var deletedVariable = await _varMoService.DeleteVariable(IdVariableMonitoreo);
            return Ok(deletedVariable); 
        }
    }
}




