using ReactorNuclear.Model;
using ReactorNuclear.Repositores;


namespace ReactorNuclear.Services
{

    public interface IMonitoreoXDispoService
    {
        Task<List<MonitoreoXDispo>> GetAll();
        Task<MonitoreoXDispo> GetMonitoreo(int IdVariableXDispositivo);
        Task<MonitoreoXDispo> CreateMonitoreo(int IdVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha);
        Task<MonitoreoXDispo> UpdateMonitoreo(int IdVariableXDispositivo, int? IdVariableMonitoreo = null, int? IdDispositivo = null, float? Valor = null, DateTime? Fecha = null);
        Task<MonitoreoXDispo> DeleteMonitoreo(int IdVariableXDispositivo);
    }
    public class MonitoreoXDispoService : IMonitoreoXDispoService
    {
        public readonly MonitoreoXDispoRepository _imxRepository;
        public MonitoreoXDispoService(MonitoreoXDispoRepository imxRepository)
        {
            _imxRepository = imxRepository;
        }

        public async Task<List<MonitoreoXDispo>> GetAll()
        {
            return await _imxRepository.GetAll();
        }

        public async Task<MonitoreoXDispo> GetMonitoreo(int IdVariableXDispositivo)
        {
            return await _imxRepository.GetMonitoreo(IdVariableXDispositivo);
        }

        public async Task<MonitoreoXDispo> CreateMonitoreo(int idVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha)
        {
            return await _imxRepository.CreateMonitoreo(idVariableMonitoreo, IdDispositivo, Valor, Fecha);
        }

        public async Task<MonitoreoXDispo> UpdateMonitoreo(int IdVariableXDispositivo, int? IdVariableMonitoreo = null, int? IdDispositivo = null, float? Valor = null, DateTime? Fecha = null)
        {
            MonitoreoXDispo newMonitoreoXDispo = await _imxRepository.GetMonitoreo(IdVariableXDispositivo);
            if(newMonitoreoXDispo != null)
            {
                if(IdVariableXDispositivo != null)
                {
                    newMonitoreoXDispo.IdVariableMonitoreo = IdVariableXDispositivo;
                }
                if(IdVariableMonitoreo != null)
                {
                    newMonitoreoXDispo.IdVariableMonitoreo = (int)IdVariableMonitoreo;
                }
                if(IdDispositivo != null)
                {
                    newMonitoreoXDispo.IdDispositivo = (int)IdDispositivo;
                }
                if(Valor != null)
                {
                    newMonitoreoXDispo.Valor= (float)Valor; 
                }
                if(Fecha != null)
                {
                    newMonitoreoXDispo.Fecha = (DateTime)Fecha;
                }
            }
            return await _imxRepository.UpdateMonitoreo(newMonitoreoXDispo);    
        }
        public async Task<MonitoreoXDispo> DeleteMonitoreo(int IdVariableXDispositivo)
        {
            return await _imxRepository.DeleteMonitoreo(IdVariableXDispositivo);
        }
    }
}
