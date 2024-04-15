using Microsoft.SqlServer.Server;

namespace ReactorNuclear.Model
{
    public class Estado_Reactor
    {
        public int Id {  get; set; }
        public required string Descripcion_Revision { get; set; }
        public required int IdTipo_Estado {  get; set; }
        //public required DateTime Fecha_Hora { get; set; }
        public required int IdAlmacenamiento {  get; set; }
        public required int IdSensores_Flujo { get; set; }
        public required int IdSensores {  get; set; }
        public required Tipo_Estado Tipo_Estado { get; set; }
        




    }
}
