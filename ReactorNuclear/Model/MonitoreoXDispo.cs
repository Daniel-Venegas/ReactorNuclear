using System.ComponentModel.DataAnnotations;

namespace ReactorNuclear.Model
{
    public class MonitoreoXDispo
    {
        [Key]
        public int IdVariableXDispositivo { get; set; }
        public required int IdVariableMonitoreo { get; set; }
        public required int IdDispositivo { get; set; }
        public required float Valor { get; set; }
        public required DateTime Fecha { get; set; }

        public VariableMonitoreo? VariableMonitoreo { get; set; }
        public Dispositivo? Dispositivo { get; set; }

        
    }
}

