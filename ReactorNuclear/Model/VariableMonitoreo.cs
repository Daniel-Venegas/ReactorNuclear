using System.ComponentModel.DataAnnotations;

namespace ReactorNuclear.Model
{
    public class VariableMonitoreo
    {
        [Key]
        public int IdVariableMonitoreo { get; set; }
        public required string VarMonitoreo { get; set; }
        public required int IdTipoVariable { get; set; }
        public TipoVariable? TipoVariable { get; set; }
    }
}
