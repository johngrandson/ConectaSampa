using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.DataAccess.Model
{
    public class PontoDeOnibus
    {
        public PontoDeOnibus()
        {
        }

        public int Id { get; set; }
        public string nome { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
