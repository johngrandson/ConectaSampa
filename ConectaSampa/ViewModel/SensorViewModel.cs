namespace dotnet.DataAccess.Model
{
    public class SensorViewModel
    {
        public int veiculoId { get; set; }
        
        public int valor { get; set; }
        public AcaoSensor acao { get; set; }
        public TipoSensor tipo { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}