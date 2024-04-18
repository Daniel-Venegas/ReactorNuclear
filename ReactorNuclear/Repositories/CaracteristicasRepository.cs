using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;

namespace ReactorNuclear.Repositores
{

    public interface ICaracteristicasRepository
    {
        Task<List<CaracteristicasI>> GetAllCaract();
        Task<CaracteristicasI> GetCaract(int IdCaracteristicas);
        Task<CaracteristicasI> CreateCaract(string CaracteristicasRequired);
        Task<CaracteristicasI> UpdateCaract(CaracteristicasI caracteristicasI);
        Task<CaracteristicasI> DeleteCaract(CaracteristicasI caracteristicasI);

        
    }
    public class CaracteristicasRepository
    {
        private readonly REDbContext _db;

        public CaracteristicasRepository(REDbContext db)
        {
            _db = db;
        }
        public async Task<List<CaracteristicasI>> GetAllCarcat()
        {
            return await _db.Caract.ToListAsync();
        }
        public async Task<CaracteristicasI> GetCaract(int IdCaracteristicas)
        {
            return await _db.Caract.FirstOrDefaultAsync(c => c.IdCaracteristicas == IdCaracteristicas);
        }
        public async Task<CaracteristicasI> CreateCaract(string CaracteristicasRequired)
        {
            CaracteristicasI newCaracteristicasI = new CaracteristicasI
            {
                CaracteristicasRequired = CaracteristicasRequired
            };

            await _db.Caract.AddAsync(newCaracteristicasI);
            _db.SaveChanges();
            return newCaracteristicasI;
        }
        public async Task<CaracteristicasI> UpdateCaract(CaracteristicasI caracteristicasI)
        {
            CaracteristicasI ConsultaUpdate = await _db.Caract.FirstOrDefaultAsync(d => d.IdCaracteristicas == caracteristicasI.IdCaracteristicas);
            if (ConsultaUpdate != null)
            {
                ConsultaUpdate.CaracteristicasRequired = caracteristicasI.CaracteristicasRequired;
                await _db.SaveChangesAsync();
            }
            return ConsultaUpdate;

        }
        public async Task<CaracteristicasI> DeleteCaract(CaracteristicasI caracteristicasI)
        {
            await _db.Caract.AddAsync(caracteristicasI);
            _db.SaveChanges ();
            return caracteristicasI;
        }

  
    }
}
