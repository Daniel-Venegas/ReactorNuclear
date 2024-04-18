using ReactorNuclear.Model;
using ReactorNuclear.Repositores;


namespace ReactorNuclear.Services
{

    public interface ICaracteristicasService
    {
        Task<List<CaracteristicasI>> GetAllcaract();
        Task<CaracteristicasI> GetCaract(int IdCaracteristicas);
        Task<CaracteristicasI> CreateCaract(string CaracteristicasRequired);
        Task<CaracteristicasI> UpdateCaract(int IdCaracteristicas, string? CaracteristicasRequired = null);
        Task<CaracteristicasI> DeleteCaract(int IdCaracteristicas);

    }
    public class CaracteristicasService
    {
        public readonly CaracteristicasRepository _caracteristicasRepository;

        public CaracteristicasService(CaracteristicasRepository caracteristicasRepository)
        {
            _caracteristicasRepository = caracteristicasRepository;
        }
        public async Task<CaracteristicasI> CreateCaract(string CaracteristicasRequired)
        {
            return await _caracteristicasRepository.CreateCaract(CaracteristicasRequired);
        }
        public async Task<List<CaracteristicasI>> GetAllCaract()
        {
            return await _caracteristicasRepository.GetAllCarcat();
        }

        public async Task<CaracteristicasI> GetCaract(int IdCaracteristicas)
        {
            return await _caracteristicasRepository.GetCaract(IdCaracteristicas);
        }

        public async Task<CaracteristicasI> UpdateCaract(int IdCaracteristicas, string? CaracteristicasRequired = null)
        {
            CaracteristicasI newCaracteristicasI = await _caracteristicasRepository.GetCaract(IdCaracteristicas);
            if (newCaracteristicasI != null)
            {
                if (CaracteristicasRequired != null)
                {
                    newCaracteristicasI.CaracteristicasRequired = CaracteristicasRequired;
                }
                return await _caracteristicasRepository.UpdateCaract(newCaracteristicasI);
            }
             throw new InvalidOperationException("Registro no encontrado.");
        }
        public async Task<CaracteristicasI> DeleteCaract (int IdCaracteristicas)
        {
            CaracteristicasI caracteristicasI = await _caracteristicasRepository.GetCaract(IdCaracteristicas);
            return await _caracteristicasRepository.DeleteCaract(caracteristicasI);
        }
    }
}
