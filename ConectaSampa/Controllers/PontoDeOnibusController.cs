using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Route("api/PontoDeOnibus")]
    public class PontoDeOnibusController : Controller
    {
        private BusHelperContext _db { get; set; }

        public PontoDeOnibusController(BusHelperContext db)
        {
            this._db = db;
        }

        [HttpGet("distanciaOnibus/{veiculoId}/{pontoId}")]
        public IActionResult DistanciaPonto(int veiculoId, int pontoId)
        {
            var calcDistanciaPonto = new CalcDistanciaPontoViewModel();

            var latVeiculo = this._db.sensores.Single(x => x.veiculo.Id == veiculoId).latitude;
            var longVeiculo = this._db.sensores.Single(x => x.veiculo.Id == veiculoId).longitude;

            var latPonto = this._db.pontosDeOnibus.Single(x => x.Id == pontoId).latitude;
            var longPonto = this._db.pontosDeOnibus.Single(x => x.Id == pontoId).longitude;


            var z1 = (latVeiculo - longVeiculo);
            var z2 = (latPonto - longPonto);

            z1 = Math.Pow(z1, 2);
            z2 = Math.Pow(z2, 2);

            var soma = z1 + z2;

            calcDistanciaPonto.distancia = Math.Sqrt(soma);

            calcDistanciaPonto.nome = this._db.pontosDeOnibus.Single(x => x.Id == pontoId).nome;

            return Ok(calcDistanciaPonto);

        }


    }
}