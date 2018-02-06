namespace dotnet.DataAccess.Model
{
    public class Sensor
    {
        public Sensor()
        {
        }

        public int Id { get; set; }
        public int valor { get; set; }
        public virtual Veiculo veiculo { get; set; }
        public AcaoSensor acao { get; set; }
        public TipoSensor tipo { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}