using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Model;
using System.Reflection.Emit;

namespace ReactorNuclear.Context
{
    public class REDbContext : DbContext
    {
        public REDbContext(DbContextOptions<REDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
        
        public DbSet<MonitoreoXDispo> monitoreoXDispos {  get; set; }
        public DbSet<Dispositivo> Dispositivo { get; set; }
        public DbSet<VariableMonitoreo> VarMo {  get; set; }
        public DbSet<DetalleDispositivo> DetalleD {  get; set; }
        public DbSet<TipoVariable> TipoV { get; set; }
        public DbSet<CaracteristicasI> Caract {  get; set; }



    }
}
