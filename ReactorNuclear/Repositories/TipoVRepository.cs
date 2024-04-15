using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;


namespace ReactorNuclear.Repositores
{

    public interface ITipoVRepository
    {
        Task<List<TipoVariable>> GetAll();
        Task<TipoVariable> GetTipoV(int IdTipoVariable);
        Task<TipoVariable> CreateTipoV(string Variable);
        Task<TipoVariable> UpdateTipoV(int IdTipoVariable, string Variable);
        Task<TipoVariable> DeleteTipoV(int IdTipoVariable);
        //Task<TipoVariable> UpdateTipoV(Dispositivo? newDispositivo);
        //Task<MonitoreoXDispo> UpdateMonitoreo(MonitoreoXDispo? newMonitoreoXDispo);
    }
    public class TipoVRepository : ITipoVRepository
    {
        private readonly REDbContext _db;

        public TipoVRepository(REDbContext db)
        {
            _db = db;
        }

        public async Task<List<TipoVariable>> GetAll()
        {
            return await _db.TipoV.ToListAsync();
        }
        public async Task<TipoVariable> GetTipoV(int IdTipoVariable)
        {
            return await _db.TipoV.FirstOrDefaultAsync(t => t.IdTipoVariable == IdTipoVariable);
        }
        public async Task<TipoVariable> CreateTipoV(string Variable)
        {
            TipoVariable newTipoVariable = new TipoVariable
            {
                Variable = Variable
            };

            await _db.TipoV.AddAsync(newTipoVariable);
            _db.SaveChanges();
            return newTipoVariable;
        }
        public async Task<TipoVariable> UpdateTipoV(int IdTipoVariable, string Variable)
        {
            /*var tipoVToUpdate = await _db.TipoV.FindAsync(IdTipoVariable);
            if (tipoVToUpdate != null)
            {

                tipoVToUpdate.IdTipoVariable = IdTipoVariable;
                tipoVToUpdate.Variable = Variable;


                await _db.SaveChangesAsync();
            }

            return tipoVToUpdate;*/
            throw new NotImplementedException();
        }
        public async Task<TipoVariable> DeleteTipoV(int IdTipoVariable)
        {
            var tipoVToDelete = await _db.TipoV.FindAsync(IdTipoVariable);

            if (tipoVToDelete != null)
            {
                _db.TipoV.Remove(tipoVToDelete);
                await _db.SaveChangesAsync();
            }
            return tipoVToDelete;
        }

        internal async Task<TipoVariable> UpdateDispo(TipoVariable? newTipoVariable)
        {
            throw new NotImplementedException();
        }
    }
}
