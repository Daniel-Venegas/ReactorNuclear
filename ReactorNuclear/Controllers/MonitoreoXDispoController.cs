using Microsoft.AspNetCore.Mvc;
using ReactorNuclear.Model;
using ReactorNuclear.Services;

namespace ReactorNuclear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoreoXDispoController : ControllerBase
    {
        private readonly IMonitoreoXDispoService _monitoreoXDispoService;

        public MonitoreoXDispoController(IMonitoreoXDispoService monitoreoXDispoService)
        {
            _monitoreoXDispoService = monitoreoXDispoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonitoreoXDispo>>> GetAllMonitoreos()
        {
            return Ok(await GetAllMonitoreos());
        }

        [HttpGet("{IdVariableXDispositivo}")]
        public async Task<ActionResult<MonitoreoXDispo>> GetMonitoreo(int IdVariableXDispositivo)
        {
            var monitoreoXDispo = await _monitoreoXDispoService.GetMonitoreo(IdVariableXDispositivo);
            if (monitoreoXDispo == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(monitoreoXDispo);
        }
        [HttpPost]
        public async Task<ActionResult<MonitoreoXDispo>> CreateMonitoreo([FromBody] MonitoreoXDispo monitoreoXDispo)
        {
            if (monitoreoXDispo == null)
            {
                return BadRequest("El objeto MonitoreoXDispositivo es nulo");
            }
            var newMonitoreo = await _monitoreoXDispoService.CreateMonitoreo(monitoreoXDispo.IdVariableMonitoreo, monitoreoXDispo.IdDispositivo, monitoreoXDispo.Valor, monitoreoXDispo.Fecha);
            return Ok(newMonitoreo);
        } 

        [HttpPut("{IdVariableXDispositivo}")]
        public async Task<ActionResult<MonitoreoXDispo>> UpdateMonitoreo(int IdVariableXDispositivo, [FromBody] MonitoreoXDispo updateMonitoreoXDispo)
        {
            if(updateMonitoreoXDispo == null || IdVariableXDispositivo <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar MonitoreoXDipositivo");
            }
            var updatedMonitoreo = await _monitoreoXDispoService.UpdateMonitoreo(IdVariableXDispositivo, updateMonitoreoXDispo.IdVariableMonitoreo, updateMonitoreoXDispo.IdDispositivo, updateMonitoreoXDispo.Valor, updateMonitoreoXDispo.Fecha);
            return Ok(updatedMonitoreo);
        }

        [HttpDelete("{IdVariableXDispositivo}")]
        public async Task<ActionResult<MonitoreoXDispo>> DeleteMonitoreo(int IdVariableXDispositivo)
        {
            if(IdVariableXDispositivo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var deletedMonitoreo = await _monitoreoXDispoService.DeleteMonitoreo(IdVariableXDispositivo);
            return Ok(deletedMonitoreo);
        }
    }
}
