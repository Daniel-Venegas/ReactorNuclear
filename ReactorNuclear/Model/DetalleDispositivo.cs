using System.ComponentModel.DataAnnotations;

namespace ReactorNuclear.Model
{
    public class DetalleDispositivo
    {
        [Key]
        public int IdDetalleDispositivo { get; set; }
        public required int IdDispositivo { get; set; }
        public required int IdCaracteristicas { get; set; }
        public required string Caracteristicas { get; set; }
        public CaracteristicasI? CaracteristicasI { get; set; }

    }
}
