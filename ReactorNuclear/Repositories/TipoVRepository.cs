using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;


namespace ReactorNuclear.Repositores
{

    public interface ITipoVRepository
    {
        Task<List<TipoVariable>> GetAllVariable();
        Task<TipoVariable> GetTipoV(int IdTipoVariable);
        Task<TipoVariable> CreateTipoV(string Variable);
        Task<TipoVariable> UpdateTipoV(TipoVariable tipoVariable);
        Task<TipoVariable> DeleteTipoV(TipoVariable tipoVariable);
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

        public async Task<List<TipoVariable>> GetAllVariable()
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
        public async Task<TipoVariable> UpdateTipoV(TipoVariable tipoVariable)
        {
            TipoVariable ConsultUpdate = await _db.TipoV.FirstOrDefaultAsync(d => d.IdTipoVariable == tipoVariable.IdTipoVariable);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Variable = tipoVariable.Variable;
                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
       
        }
        public async Task<TipoVariable> DeleteTipoV(TipoVariable tipoVariable)
        {
            await _db.TipoV.AddAsync(tipoVariable);
            await _db.SaveChangesAsync();
            return tipoVariable;
        }

   
    }
}
