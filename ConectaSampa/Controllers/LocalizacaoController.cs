using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using dotnet.DataAccess;
using dotnet.Services;
using dotnet.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnet.Controllers
{
    [Route("api/Localizacao")]
    public class LocalizacaoController : Controller
    {
        private BusHelperContext _db { get; set; }

        public LocalizacaoController(BusHelperContext db)
        {
            this._db = db;
        }

        // Uso da google api Geocode
        [HttpGet("{pontoId}")]
        public IActionResult LocalizaPonto(int pontoId)
        {
            WebClient con = new WebClient();

            var lat = this._db.pontosDeOnibus.Where(x => x.Id == pontoId).Select(x => x.latitude).FirstOrDefault().ToString();
            var lng = this._db.pontosDeOnibus.Where(x => x.Id == pontoId).Select(x => x.longitude).FirstOrDefault().ToString();


            var url = con.DownloadString($"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key=AIzaSyCXPixQua9NpsjwLDnhBnhe3qv-yzlv4z4");


            var result = JsonConvert.DeserializeObject(url);

            return Ok(result);
        }


        // Uso da google api Distance Matrix
        [HttpPost("{distancia}")]
        public IActionResult DistanciaPonto([FromBody]LocalizacaoViewModel model)
        {
            WebClient con = new WebClient();
            var origem = model.localizacao;
            var destino = model.destino;

            origem = string.Join("+", origem.ToString());
            destino = string.Join("+", destino.ToString());

            var url = con.DownloadString($"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={origem}&destinations={destino}&mode=bicycling&language=pt-BR&key=AIzaSyCXPixQua9NpsjwLDnhBnhe3qv-yzlv4z4");

            var result = JsonConvert.DeserializeObject(url);

            return Ok(result);
        }

        // Uso da google api Distance Matrix
        [HttpPost("{direcao}")]
        public IActionResult DirecaoPonto([FromBody]LocalizacaoViewModel model)
        {
            WebClient con = new WebClient();
            var origem = model.localizacao;
            var destino = model.destino;

            origem = string.Join("+", origem.ToString());
            destino = string.Join("+", destino.ToString());

            var url = con.DownloadString($"https://maps.googleapis.com/maps/api/directions/json?units=metric&origin={origem}&destination={destino}&mode=bicycling&language=pt-BR&key=AIzaSyCXPixQua9NpsjwLDnhBnhe3qv-yzlv4z4");

            var result = JsonConvert.DeserializeObject(url);

            return Ok(result);
        }



    }
}