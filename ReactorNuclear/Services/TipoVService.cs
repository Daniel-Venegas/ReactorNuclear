using ReactorNuclear.Model;
using ReactorNuclear.Repositores;


namespace ReactorNuclear.Services
{

    public interface ITipoVService
    {
        Task<List<TipoVariable>> GetAllVariable();
        Task<TipoVariable> GetTipoV(int IdTipoVariable);
        Task<TipoVariable> CreateTipoV(string Variable);
        Task<TipoVariable> UpdateTipoV(int IdTipoVariable, string? Variable = null);
        Task<TipoVariable> DeleteTipoV(int IdTipoVariable);
        
    }
    public class TipoVService : ITipoVService
    {
        public readonly TipoVRepository _tipoVRepository;

        public TipoVService(TipoVRepository tipoVRepository)
        {
            _tipoVRepository = tipoVRepository;
        }
        public async Task<TipoVariable> CreateTipoV(string Variable)
        {
            return await _tipoVRepository.CreateTipoV(Variable);

        }
        public async Task<List<TipoVariable>> GetAllVariable()
        {
            return await _tipoVRepository.GetAllVariable();
        }
        public async Task<TipoVariable> GetTipoV(int IdTipoVariable)
        {
            return await _tipoVRepository.GetTipoV(IdTipoVariable);
        }
        public async Task<TipoVariable> UpdateTipoV(int IdTipoVariable, string? Variable = null)
        {
            TipoVariable newTipoVariable = await _tipoVRepository.GetTipoV(IdTipoVariable);
            if (newTipoVariable != null)
            {
                if (Variable != null)
                {
                    newTipoVariable.Variable = Variable;
                }
                return await _tipoVRepository.UpdateTipoV(newTipoVariable);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }

        public async Task<TipoVariable> DeleteTipoV(int IdTipoVariable)
        {
            TipoVariable tipoVariable = await _tipoVRepository.GetTipoV(IdTipoVariable);
            return await _tipoVRepository.DeleteTipoV(tipoVariable);
        }
    }
}
