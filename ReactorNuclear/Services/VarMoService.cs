using ReactorNuclear.Model;
using ReactorNuclear.Repositores;

namespace ReactorNuclear.Services
{

    public interface IVarMoService
    {
        Task<List<VariableMonitoreo>> GetAllVarMo();
        Task<VariableMonitoreo> GetVar(int IdVariableMonitoreo);
        Task<VariableMonitoreo> CreateVarMo(string VarMonitoreo, int IdTipoVariable);
        Task<VariableMonitoreo> UpdateVarMo(int IdVariableMonitoreo, string? VarMonitoreo = null, int? IdTipoVariable = null);
        Task<VariableMonitoreo> DeleteVariable(int IdVariableMonitoreo);
    }
    public class VarMoService : IVarMoService
    {
        public readonly IVarMoRepository _varMoRepository;

        public VarMoService(IVarMoRepository varMoRepository)
        {
            _varMoRepository = varMoRepository;
        }
        public async Task<VariableMonitoreo> CreateVarMo(string VarMonitoreo, int IdTipoVariable)
        {
            return await _varMoRepository.CreateVarMo(VarMonitoreo, IdTipoVariable);
        }

        public Task<VariableMonitoreo> DeleteVarMo(int IdVariableMonitoreo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VariableMonitoreo>> GetAllVarMo()
        {
            return await _varMoRepository.GetAllVarMo();
        }
        public async Task<VariableMonitoreo> GetVar(int IdVariableMonitoreo)
        {
            return await _varMoRepository.GetVar(IdVariableMonitoreo);
        }
        public async Task<VariableMonitoreo> UpdateVarMo(int IdVariableMonitoreo, string? VarMonitoreo = null, int? IdTipoVariable = null)
        {
            VariableMonitoreo newVariableMonitoreo = await _varMoRepository.GetVar(IdVariableMonitoreo);
            if (newVariableMonitoreo != null)
            {
                if (VarMonitoreo != null)
                {
                    newVariableMonitoreo.VarMonitoreo = VarMonitoreo;
                }
                if (IdTipoVariable != null)
                {
                    newVariableMonitoreo.IdTipoVariable = (int)IdTipoVariable;
                }
                return await _varMoRepository.UpdateVarMo(newVariableMonitoreo);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
        public async Task<VariableMonitoreo> DeleteVariable(int IdVariableMonitoreo)
        {
            VariableMonitoreo variableMonitoreo = await _varMoRepository.GetVar(IdVariableMonitoreo);
            return await _varMoRepository.DeleteVarMo(variableMonitoreo);
        }
    }
}
