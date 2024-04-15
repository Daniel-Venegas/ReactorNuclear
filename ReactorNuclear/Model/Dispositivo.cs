using System.ComponentModel.DataAnnotations;

namespace ReactorNuclear.Model
{
    public class Dispositivo
    {
        [Key]
        public int IdDispositivo {  get; set; }
        public required string Dispo {  get; set; }
        public DetalleDispositivo? DetalleDispositivo { get; set; }

    }
}
