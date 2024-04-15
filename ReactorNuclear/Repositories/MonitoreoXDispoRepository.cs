using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;

namespace ReactorNuclear.Repositores
{

    public interface IMonitoreoXDispoRepository
    {
        Task<List<MonitoreoXDispo>> GetAll();
        Task<MonitoreoXDispo> GetMonitoreo(int IdVariableMonitoreo);
        Task<MonitoreoXDispo> CreateMonitoreo(int IdVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha);
        Task<MonitoreoXDispo> UpdateMonitoreo(int IdVariableXDispositivo, int IdVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha);
        Task<MonitoreoXDispo> DeleteMonitoreo(int IdVaraibleXDispositivo);
        Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo? newMonitoreoXDispo);
        //Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo? newMonitoreoXDispo);
    }
    public class MonitoreoXDispoRepository : IMonitoreoXDispoRepository
    {
        private readonly REDbContext _db;

        public MonitoreoXDispoRepository (REDbContext db)
        {
            _db = db;
        }

        public async Task<List<MonitoreoXDispo>> GetAll()
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

        public async Task<MonitoreoXDispo> UpdateMonitoreo(int IdVariableXDispositivo, int IdVariableMonitoreo, int IdDispositivo, float Valor, DateTime Fecha)
        {

            /*var monitoreoToUpdate = await _db.monitoreoXDispos.FindAsync(IdVariableXDispositivo);

            if (monitoreoToUpdate != null)
            {
                
                monitoreoToUpdate.IdVariableMonitoreo = IdVariableMonitoreo;
                monitoreoToUpdate.IdDispositivo = IdDispositivo;
                monitoreoToUpdate.Valor = Valor;
                monitoreoToUpdate.Fecha = Fecha;

                
                await _db.SaveChangesAsync();
            }

            return monitoreoToUpdate;*/
            throw new NotImplementedException();
        }


        public async Task<MonitoreoXDispo> DeleteMonitoreo(int IdVaraibleXDispositivo)
        {

            var monitoreoToDelete = await _db.monitoreoXDispos.FindAsync(IdVaraibleXDispositivo);

            if (monitoreoToDelete != null)
            {
                _db.monitoreoXDispos.Remove(monitoreoToDelete);
                await _db.SaveChangesAsync();
            }

            return monitoreoToDelete;
        }

        public async Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo? newMonitoreoXDispo)
        {
            throw new NotImplementedException();
        }
    }
}