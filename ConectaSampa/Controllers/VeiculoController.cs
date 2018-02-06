using System.Collections.Generic;
using System.Linq;
using dotnet.DataAccess;
using dotnet.DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : Controller
    {
        public BusHelperContext _db { get; set; }
        
        public VeiculoController(BusHelperContext db)
        {
            this._db = db;
        }
        /// <summary>
        /// Retorna todos os veiculos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de veiculos</returns>
        [HttpGet]
        public IEnumerable<Veiculo> Get()
        {
            return this._db.veiculos.ToList();
        }

        [HttpGet("{id}")]
        public ResumoVeiculoViewModel Get(int id)
        {
            var veiculo = this._db.veiculos.Single(v => v.Id == id);
            var historico = this._db.historicoSensores
                                .Include(h => h.sensor)
                                .ThenInclude(s => s.veiculo)
                                .Where(h => h.sensor.veiculo.Id == id);
            var entradas = historico.Where(h => h.sensor.acao == AcaoSensor.Entrada).Count();
            var saidas = historico.Where(h => h.sensor.acao == AcaoSensor.Saida).Count();
            var total = entradas - saidas;
            var capacidade = veiculo.capacidadeSentados + veiculo.capacisadeEmPe;
            var lotacao = 0;

            if(total > 0){
                lotacao = (total * 100) / capacidade;
            }

            var detalhes = new ResumoVeiculoViewModel();
            detalhes.capacidadeSentados = veiculo.capacidadeSentados;
            detalhes.capacisadeEmPe = veiculo.capacisadeEmPe;
            detalhes.lotacao = string.Format("{0:N2}%", lotacao);
            detalhes.nome = veiculo.nome;
            detalhes.Id = veiculo.Id;

            return detalhes;
        }

        /// <summary>
        /// Cadastra um novo veiculo
        /// </summary>
        /// <param name="model">Dados do veiculo</param>
        [HttpPost]
        public void Post([FromBody]VeiculoViewModel model)
        {
            var veiculo = new Veiculo();
            veiculo.nome = model.nome;
            veiculo.capacidadeSentados = model.capacidadeSentados;
            veiculo.capacisadeEmPe = model.capacisadeEmPe;

            this._db.veiculos.Add(veiculo);
            this._db.SaveChanges();
        }

        /// <summary>
        /// Atualiza os dados de um veiculo
        /// </summary>
        /// <param name="id">Código do veiculo</param>
        /// <param name="model">Dados do veiculo</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]VeiculoViewModel model)
        {
            var veiculo = this._db.veiculos.Single(v => v.Id == id);
            veiculo.nome = model.nome;
            veiculo.capacidadeSentados = model.capacidadeSentados;
            veiculo.capacisadeEmPe = model.capacisadeEmPe;

            this._db.veiculos.Update(veiculo);
            this._db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var veiculo = this._db.veiculos.Single(v => v.Id == id);

            this._db.veiculos.Remove(veiculo);
            this._db.SaveChanges();
        }
    }
}
