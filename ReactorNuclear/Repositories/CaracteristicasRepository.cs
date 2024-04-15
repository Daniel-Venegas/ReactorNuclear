using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;

namespace ReactorNuclear.Repositores
{

    public interface ICaracteristicasRepository
    {
        Task<List<CaracteristicasI>> GetAll();
        Task<CaracteristicasI> GetCaract(int IdCaracteristicas);
        Task<CaracteristicasI> CreateCaract(string CaracteristicasRequired);
        Task<CaracteristicasI> UpdateCaract(int IdCaracteristicas, string CaracteristicasRequired);
        Task<CaracteristicasI> DeleteCaract(int IdCaracteristicas);
        
    }
    public class CaracteristicasRepository
    {
        private readonly REDbContext _db;

        public CaracteristicasRepository(REDbContext db)
        {
            _db = db;
        }
        public async Task<List<CaracteristicasI>> GetAll()
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
        public async Task<CaracteristicasI> UpdateCaract(int IdCaracteristicas, string CaracteristicasRequired)
        {
            /*var caractToUpdate = await _db.Caract.FindAsync(IdCaracteristicas);
            if (caractToUpdate != null)
            {

                caractToUpdate.IdCaracteristicas = IdCaracteristicas;
                caractToUpdate.CaracteristicasRequired = CaracteristicasRequired;


                await _db.SaveChangesAsync();
            }

            return caractToUpdate;*/
            throw new NotImplementedException();
        }
        public async Task<CaracteristicasI> DeleteCaract(int IdCaracteristicas)
        {
            var caractToDelete = await _db.Caract.FindAsync(IdCaracteristicas);

            if (caractToDelete != null)
            {
                _db.Caract.Remove(caractToDelete);
                await _db.SaveChangesAsync();
            }
            return caractToDelete;
        }

        internal async Task<CaracteristicasI> UpdateDispo(CaracteristicasI? newCaracteristicasI)
        {
            throw new NotImplementedException();
        }
    }
}
