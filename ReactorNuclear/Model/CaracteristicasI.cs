using System.ComponentModel.DataAnnotations;

namespace ReactorNuclear.Model
{
    public class CaracteristicasI
    {
        [Key]
        public int IdCaracteristicas { get; set; }
        public required string CaracteristicasRequired { get; set;}
        
    }
}
