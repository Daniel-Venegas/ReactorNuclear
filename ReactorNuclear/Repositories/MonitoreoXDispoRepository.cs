using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;

namespace ReactorNuclear.Repositores
{

    public interface IMonitoreoXDispoRepository
    {
        Task<List<MonitoreoXDispo>> GetAllMonitoreos();
        Task<MonitoreoXDispo> GetMonitoreo(int IdVariableMonitoreo);
        Task<MonitoreoXDispo> CreateMonitoreo(int IdVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha);
        Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo monitoreoXDispo);
        Task<MonitoreoXDispo> DeleteMonitoreo(MonitoreoXDispo monitoreoXDispo);
 
    }
    public class MonitoreoXDispoRepository : IMonitoreoXDispoRepository
    {
        private readonly REDbContext _db;

        public MonitoreoXDispoRepository (REDbContext db)
        {
            _db = db;
        }

        public async Task<List<MonitoreoXDispo>> GetAllMonitoreos()
        {
            return await _db.monitoreoXDispos.ToListAsync();
        }

        public async Task<MonitoreoXDispo> CreateMonitoreo(int IdVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha)
        {
            MonitoreoXDispo newMonitoreoXDispo = new MonitoreoXDispo
            {
                IdVariableMonitoreo=IdVariableMonitoreo,
                IdDispositivo=IdDispositivo,
                Valor=Valor,
                Fecha=Fecha
            };

            await _db.monitoreoXDispos.AddAsync(newMonitoreoXDispo);
            _db.SaveChanges();
            return newMonitoreoXDispo;
        }


        public async Task<MonitoreoXDispo> GetMonitoreo(int IdVariableMonitoreo)
        {
            return await _db.monitoreoXDispos.FirstOrDefaultAsync(m => m.IdVariableXDispositivo == IdVariableMonitoreo);
        }

        public async Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo monitoreoXDispo)
        {
            MonitoreoXDispo ConsultUpdate = await _db.monitoreoXDispos.FirstOrDefaultAsync(d => d.IdVariableXDispositivo == monitoreoXDispo.IdVariableXDispositivo);
            if(ConsultUpdate != null)
            {
                ConsultUpdate.IdVariableMonitoreo = monitoreoXDispo.IdVariableMonitoreo;
                ConsultUpdate.IdDispositivo = monitoreoXDispo.IdDispositivo;
                ConsultUpdate.Valor = monitoreoXDispo.Valor;
                ConsultUpdate.Fecha = monitoreoXDispo.Fecha;
                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
        }


        public async Task<MonitoreoXDispo> DeleteMonitoreo(MonitoreoXDispo monitoreoXDispo)
        {
            await _db.monitoreoXDispos.AddAsync(monitoreoXDispo);
            _db.SaveChanges();
            return monitoreoXDispo;
        }

 
    }
}