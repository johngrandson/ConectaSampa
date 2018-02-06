namespace dotnet.DataAccess.Model
{
    public class Veiculo
    {
        public Veiculo()
        {
        }

        public int Id { get; set; }
        public string nome { get; set; }
        public int capacidadeSentados { get; set; }
        public int capacisadeEmPe { get; set; }
    }
}