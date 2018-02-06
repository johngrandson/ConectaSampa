using System;

namespace dotnet.DataAccess.Model
{
    public class HistoricoSensor
    {
        public HistoricoSensor()
        {
        }

        public int Id { get; set; }
        public int valor { get; set; }
        public DateTime data { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Sensor sensor { get; set; }
    }
}