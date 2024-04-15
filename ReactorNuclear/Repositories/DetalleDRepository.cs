using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Context;
using ReactorNuclear.Model;
using System.Drawing;

namespace ReactorNuclear.Repositores
{

    public interface IDetalleDRepository
    {
        Task<List<DetalleDispositivo>> GetAll();
        Task<DetalleDispositivo> GetDetalleD(int IdDetalleDispositivo);
        Task<DetalleDispositivo> CreateDetalleD(int IdDispositivo, int IdCaracteristicas, string Caracteristicas);
        Task<DetalleDispositivo> UpdateDetalleD(DetalleDispositivo detalleDispositivo );
        Task<DetalleDispositivo> DeleteDetalleD(DetalleDispositivo detalleDispositivo);

    }
    public class DetalleDRepository : IDetalleDRepository
    {

        private readonly REDbContext _db;

        public DetalleDRepository(REDbContext db)
        {
            _db = db;
        }

        public async Task<List<DetalleDispositivo>> GetAll()
        {
            return await _db.DetalleD.ToListAsync();
        }

        public async Task<DetalleDispositivo> GetDetalleD(int IdDetalleDispositivo)
        {
            return await _db.DetalleD.FirstOrDefaultAsync(d => d.IdDetalleDispositivo == IdDetalleDispositivo);
        }

        public async Task<DetalleDispositivo> CreateDetalleD(int IdDispositivo, int IdCaracteristicas, string Caracteristicas)
        {
            DetalleDispositivo newDetalleDispositivo = new DetalleDispositivo
            {
                IdDispositivo = IdDispositivo,
                IdCaracteristicas = IdCaracteristicas,
                Caracteristicas = Caracteristicas
            };

            await _db.DetalleD.AddAsync(newDetalleDispositivo);
            await _db.SaveChangesAsync();  
            return newDetalleDispositivo;
        }
        public async Task<DetalleDispositivo> UpdateDetalleD(DetalleDispositivo detalleDispositivo)
        {
            DetalleDispositivo ConsultUpdate = await _db.DetalleD.FirstOrDefaultAsync(d => d.IdDetalleDispositivo == detalleDispositivo.IdDetalleDispositivo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.IdCaracteristicas = detalleDispositivo.IdCaracteristicas;
                ConsultUpdate.IdDispositivo = detalleDispositivo.IdDispositivo;
                ConsultUpdate.CaracteristicasI = detalleDispositivo.CaracteristicasI;
                await _db.SaveChangesAsync();  
            }
            return ConsultUpdate;
          
        }



        public async Task<DetalleDispositivo> DeleteDetalleD(DetalleDispositivo detalleDispositivo)
        {
            await _db.DetalleD.AddAsync(detalleDispositivo);
            _db.SaveChanges();
            return detalleDispositivo;
        }

        
    }
}

