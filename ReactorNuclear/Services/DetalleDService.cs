using ReactorNuclear.Model;
using ReactorNuclear.Repositores;

namespace ReactorNuclear.Services
{

    public interface IDetalleDService
    {
            Task<List<DetalleDispositivo>> GetAll();
            Task<DetalleDispositivo> GetDetalleD(int IdDetalleDispositivo);
            Task<DetalleDispositivo> CreateDetalleD(int IdDispositivo, int IdCaracteristicas, string Caracteristicas);
            Task<DetalleDispositivo> UpdateDetalleD(int IdDetalleDispositivo, int? IdDispositivo = null, int? IdCaracteristicas = null, string? Caracteristicas = null);
            Task<DetalleDispositivo> DeleteDetalleD(int IdDetalleDispositivo);

    }
    public class DetalleDService : IDetalleDService
    {
        public readonly DetalleDRepository _detalleRepository;

        public DetalleDService(DetalleDRepository detalleDRepository)
        {
            _detalleRepository = detalleDRepository;
        }

        public async Task<DetalleDispositivo> CreateDetalleD(int IdDispositivo, int IdCaracteristicas, string Caracteristicas)
        {
            return await _detalleRepository.CreateDetalleD(IdDispositivo, IdCaracteristicas, Caracteristicas);
        }

        public async Task<List<DetalleDispositivo>> GetAll()
        {
            return await _detalleRepository.GetAll();
        }

        public async Task<DetalleDispositivo> GetDetalleD(int IdDetalleDispositivo)
        {
            return await _detalleRepository.GetDetalleD(IdDetalleDispositivo);
        }

        public async Task<DetalleDispositivo> UpdateDetalleD(int IdDetalleDispositivo, int? IdDispositivo = null, int? IdCaracteristicas = null, string? Caracteristicas = null)
        {
            DetalleDispositivo newDetalleDispositivo = await _detalleRepository.GetDetalleD(IdDetalleDispositivo);
            if (newDetalleDispositivo != null)
            {
               
                if (IdDispositivo != null)
                {
                    newDetalleDispositivo.IdDispositivo = (int)IdDispositivo;
                }
                if (IdCaracteristicas != null)
                {
                    newDetalleDispositivo.IdCaracteristicas = (int)IdCaracteristicas;
                }
                if (Caracteristicas != null)
                {
                    newDetalleDispositivo.Caracteristicas = Caracteristicas;
                }
                return await _detalleRepository.UpdateDetalleD(newDetalleDispositivo);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }

        public async Task<DetalleDispositivo> DeleteDetalleD(int IdDetalleDispositivo)
        {
            DetalleDispositivo detalleDispositivo = await _detalleRepository.GetDetalleD(IdDetalleDispositivo);
            return await _detalleRepository.DeleteDetalleD(detalleDispositivo);
        }
    }
}

