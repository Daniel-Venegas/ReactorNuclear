using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;

namespace ReactorNuclear.Repositores
{
    public interface IDispRepository
    {
        Task<List<Dispositivo>> GetAll();
        Task<Dispositivo> GetDispo(int IdDispositivo);
        Task<Dispositivo> CreateDispo(string Dispo);
        Task<Dispositivo> UpdateDispo(int IdDispositivo, string Dispo);
        Task<Dispositivo> DeleteDispo(int IdDispositivo);
        Task<Dispositivo> UpdateDispo(Dispositivo? newDispositivo);
        //Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo? newMonitoreoXDispo);
    }
    public class DispRepository : IDispRepository
    {

        private readonly REDbContext _db;

        public DispRepository (REDbContext db) 
        {  
            _db = db; 
        }

        public async Task<List<Dispositivo>> GetAll()
        {
            return await _db.Dispositivo.ToListAsync();
        }

        public async Task<Dispositivo> GetDispo (int IdDispositivo)
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
            _db.SaveChanges();
            return newDispositivo;
        }

        public async Task<Dispositivo> UpdateDispo(int IdDispositivo, string Dispo)
        {
            /*var dispoToUpdate = await _db.Dispositivo.FindAsync(IdDispositivo);
            if (dispoToUpdate != null)
            {

                dispoToUpdate.IdDispositivo = IdDispositivo;
                dispoToUpdate.Dispo = Dispo;


                await _db.SaveChangesAsync();
            }

            return dispoToUpdate;*/
            throw new NotImplementedException();
        }

        public async Task<Dispositivo> DeleteDispo(int idDispositivo)
        {
            var dispoToDelete = await _db.Dispositivo.FindAsync(idDispositivo);

            if(dispoToDelete != null)
            {
                _db.Dispositivo.Remove(dispoToDelete);
                await _db.SaveChangesAsync();
            }
            return dispoToDelete;
        }

        public async Task<Dispositivo> UpdateDispo(Dispositivo? newDispositivo)
        {
            throw new NotImplementedException();
        }


    }
}
