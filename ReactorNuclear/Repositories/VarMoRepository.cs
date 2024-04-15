using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;

namespace ReactorNuclear.Repositores
{
    public interface IVarMoRepository
    {
        Task<List<VariableMonitoreo>> GetAll();
        Task<VariableMonitoreo> GetVar(int IdVariableMonitoreo);
        Task<VariableMonitoreo> CreateVarMo(string VarMonitoreo, int IdTipoVariable);
        Task<VariableMonitoreo> UpdateVarMo(int IdVariableMonitoreo, string VarMonitoreo, int IdTipoVariable);
        Task<VariableMonitoreo> DeleteVarMo(int IdVariableMonitoreo);
        Task<VariableMonitoreo> UpdateVarMo(VariableMonitoreo? newVariableMonitoreo);
    }
    public class VarMoRepository : IVarMoRepository
    {
        private readonly REDbContext _db;

        public VarMoRepository(REDbContext db) 
        {  
            _db = db; 
        }

        public async Task<List<VariableMonitoreo>> GetAll()
        {
            return await _db.VarMo.ToListAsync();
        }

        public async Task<VariableMonitoreo> GetVar(int IdVariableMonitoreo)
        {
            return await _db.VarMo.FirstOrDefaultAsync(v => v.IdVariableMonitoreo == IdVariableMonitoreo);
        }

        public async Task<VariableMonitoreo> CreateVarMo(string VarMonitoreo, int IdTipoVariable)
        {
            VariableMonitoreo newVariableMonitoreo = new VariableMonitoreo
            {
                VarMonitoreo = VarMonitoreo,
                IdTipoVariable = IdTipoVariable
            };

            await _db.VarMo.AddAsync(newVariableMonitoreo);
            _db.SaveChanges();
            return newVariableMonitoreo;
        }

        public async Task<VariableMonitoreo> UpdateVarMo(int IdVariableMonitoreo, string VarMonitoreo, int IdTipoVariable)
        {
            throw new NotImplementedException();
        }

        public async Task<VariableMonitoreo> DeleteVarMo(int IdVariableMonitoreo)
        {
            var varMoToDelete = await _db.VarMo.FindAsync(IdVariableMonitoreo);
            if(varMoToDelete != null)
            {
                _db.VarMo.Remove(varMoToDelete);
                await _db.SaveChangesAsync();
            }
            return varMoToDelete;
        }

        public Task<VariableMonitoreo> UpdateVarMo(VariableMonitoreo? newVariableMonitoreo)
        {
            throw new NotImplementedException();
        }
    }
}
