using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.DataAccess.Model
{
    public class Feedback
    {
        public Feedback()
        {
            
        }

        public int Id { get; set; }
        public Assunto assunto { get; set; }
        public string mensagem { get; set; }
    }
}
