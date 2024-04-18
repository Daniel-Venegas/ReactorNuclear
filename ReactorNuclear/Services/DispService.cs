using ReactorNuclear.Model;
using ReactorNuclear.Repositores;

namespace ReactorNuclear.Services
{

    public interface IDispService
    {
        Task<List<Dispositivo>> GetAllDisp();
        Task<Dispositivo> GetDispo(int IdDispositivo);
        Task<Dispositivo> CreateDispo(string Dispo);
        Task<Dispositivo> UpdateDispo(int IdDispositivo, string? Dispo = null);
        Task<Dispositivo> DeleteDispo(int IdDispositivo);
    }
    public class DispService : IDispService
    {
        public readonly DispRepository _dispRepository;

        public DispService(DispRepository dispRepository)
        {
            _dispRepository = dispRepository;
        }

        public async Task<Dispositivo> CreateDispo(string Dispo)
        {
            return await _dispRepository.CreateDispo(Dispo);
        }

        public async Task<List<Dispositivo>> GetAllDisp()
        {
            return await _dispRepository.GetAllDisp();
        }

        public async Task<Dispositivo> GetDispo(int IdDispositivo)
        {
            return await _dispRepository.GetDispo(IdDispositivo);
        }

        public async Task<Dispositivo> UpdateDispo(int idDispositivo, string? Dispo= null)
        {
            Dispositivo newDispositivo = await _dispRepository.GetDispo(idDispositivo);
            if(newDispositivo != null)
            {
                if(Dispo != null)
                    newDispositivo.Dispo = Dispo;
            }
            return await _dispRepository.UpdateDispo(newDispositivo);
        }

        public async Task<Dispositivo> DeleteDispo(int idDispositivo)
        {
            Dispositivo dispositivo = await _dispRepository.GetDispo(idDispositivo);
            return await _dispRepository.DeleteDispo(dispositivo);
        }
    }
}
