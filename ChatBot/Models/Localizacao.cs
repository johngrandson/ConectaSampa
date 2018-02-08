using Newtonsoft.Json;

namespace ChatBot.Models
{

    public class Localizacao
    {
        [JsonProperty("localizacao")]
        public string Origem { get; set; }

        [JsonProperty("destino")]
        public string Destino { get; set; }
    }
}