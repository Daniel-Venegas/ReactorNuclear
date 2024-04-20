using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;

namespace ReactorNuclear.Repositores
{
    public interface IDispRepository
    {
        Task<List<Dispositivo>> GetAllDisp();
        Task<Dispositivo> GetDispo(int IdDispositivo);
        Task<Dispositivo> CreateDispo(string Dispo);
        Task<Dispositivo> UpdateDispo(Dispositivo dispositivo);
        Task<Dispositivo> DeleteDispo(Dispositivo dispositivo);
        //Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo? newMonitoreoXDispo);
    }
    public class DispRepository : IDispRepository
    {

        private readonly REDbContext _db;

        public DispRepository(REDbContext db)
        {
            _db = db;
        }

        public async Task<List<Dispositivo>> GetAllDisp()
        {
            return await _db.Dispositivo.ToListAsync();
        }

        public async Task<Dispositivo> GetDispo(int IdDispositivo)
        {
            return await _db.Dispositivo.FirstOrDefaultAsync(d => d.IdDispositivo == IdDispositivo);
        }

        public async Task<Dispositivo> CreateDispo(string Dispo)
        {
            Dispositivo newDispositivo = new Dispositivo
            {
                Dispo = Dispo
            };

            await _db.Dispositivo.AddAsync(newDispositivo);
            await _db.SaveChangesAsync();
            return newDispositivo;
        }

        public async Task<Dispositivo> UpdateDispo(Dispositivo dispositivo)
        {
            Dispositivo ConsultUpdate = await _db.Dispositivo.FirstOrDefaultAsync(d => d.IdDispositivo == dispositivo.IdDispositivo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Dispo = dispositivo.Dispo;
                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
        }



        public async Task<Dispositivo> DeleteDispo(Dispositivo dispositivo)
        {
            await _db.Dispositivo.AddAsync(dispositivo);
            _db.SaveChanges();
            return dispositivo;
        }

    }
}
