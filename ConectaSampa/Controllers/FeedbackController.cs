using System.Collections.Generic;
using System.Linq;
using dotnet.DataAccess;
using dotnet.DataAccess.Model;
using dotnet.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Route("api/feedback")]
    public class FeedbackController : Controller
    {
        private BusHelperContext _db { get; set; }

        public FeedbackController(BusHelperContext db)
        {
            this._db = db;
        }

        public IEnumerable<Feedback> Get()
        {
            return this._db.feedbacks.ToList();
        }

        [HttpGet("{id}")]
        public Feedback Get(int id)
        {
            return this._db.feedbacks.Single(x => x.Id == id);
        }


        [HttpPost]
        public Feedback Post([FromBody] FeedbackViewModel model)
        {
            var feedback = new Feedback();

            feedback.assunto = model.assunto;
            feedback.mensagem = model.mensagem;

            this._db.feedbacks.Add(feedback);
            this._db.SaveChanges();

            return feedback;
        }
    }
}