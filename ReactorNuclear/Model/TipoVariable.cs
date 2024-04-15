using System.ComponentModel.DataAnnotations;

namespace ReactorNuclear.Model
{
    public class TipoVariable
    {
        [Key]
        public int IdTipoVariable {  get; set; }
        public required string Variable {  get; set; }
    }
}
