using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shop.Models
{
    public class Usuario
    {

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("ativo")]
        public bool? Ativo { get; set; }
    }
}