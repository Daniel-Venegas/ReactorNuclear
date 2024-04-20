using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;

namespace ReactorNuclear.Repositores
{
    public interface IVarMoRepository
    {
        Task<List<VariableMonitoreo>> GetAllVarMo();
        Task<VariableMonitoreo> GetVar(int IdVariableMonitoreo);
        Task<VariableMonitoreo> CreateVarMo(string VarMonitoreo, int IdTipoVariable);
        Task<VariableMonitoreo> UpdateVarMo(VariableMonitoreo variableMonitoreo);
        Task<VariableMonitoreo> DeleteVarMo(VariableMonitoreo variableMonitoreo);
   
    }
    public class VarMoRepository : IVarMoRepository
    {
        private readonly REDbContext _db;

        public VarMoRepository(REDbContext db) 
        {  
            _db = db; 
        }

        public async Task<List<VariableMonitoreo>> GetAllVarMo()
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

        public async Task<VariableMonitoreo> UpdateVarMo(VariableMonitoreo variableMonitoreo)
        {
            VariableMonitoreo ConsultaUpdate = await _db.VarMo.FirstOrDefaultAsync(d => d.IdVariableMonitoreo == variableMonitoreo.IdVariableMonitoreo);
           if (ConsultaUpdate != null)
            {
                ConsultaUpdate.VarMonitoreo = variableMonitoreo.VarMonitoreo;
                ConsultaUpdate.IdTipoVariable = variableMonitoreo.IdTipoVariable;
                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;
        }

        public async Task<VariableMonitoreo> DeleteVarMo(VariableMonitoreo variableMonitoreo)
        {
            await _db.VarMo.AddAsync(variableMonitoreo);
            await _db.SaveChangesAsync();
            return variableMonitoreo;
        }


    }
}
