using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DataAccess.Model;
using dotnet.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Velyo.Google.Services;

namespace dotnet.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private BusHelperContext _db { get; set; }

        public UsuarioController(BusHelperContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this._db.usuarios.ToList();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return this._db.usuarios.Single(x => x.Id == id);
        }

        [HttpPost("distancia/{veiculoId}")]
        public IActionResult Distancia(int veiculoId, [FromBody]CalculaDistanciaViewModel usuario)
        {
            var distanciaViewModel = new DistanciaViewModel();

            var sensor = this._db.sensores.Single(x => x.veiculo.Id == veiculoId);

            var y1 = usuario.latitude;
            var x1 = usuario.longitude;
            var y2 = sensor.latitude;
            var x2 = sensor.longitude;

            var z1 = (x2 - x1);
            var z2 = (y2 - y1);

            z1 = Math.Pow(z1, 2);
            z2 = Math.Pow(z2, 2);


            var soma = z1 + z2;

            var distancia = Math.Sqrt(soma);

            distanciaViewModel.veiculoId = this._db.veiculos.FirstOrDefault(x => x.Id == veiculoId).Id;
            distanciaViewModel.nome = this._db.veiculos.FirstOrDefault(x => x.Id == veiculoId).nome;
            distanciaViewModel.distancia = distancia;

            return Ok(distanciaViewModel);
        }


    }
}