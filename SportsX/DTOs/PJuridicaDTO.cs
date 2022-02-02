using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportsX.DTOs
{
    public class PJuridicaDTO
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatória e deve conter no máximo 100 caracteres!")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Razão Social")]
        public string DS_RAZAO_SOCIAL { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório!")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        public string DS_EMAIL { get; set; }

        [Required(ErrorMessage = "Classificação obrigatório!")]
        [DisplayName("Classificação")]
        public bool DS_CLASSIFICACAO { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório!")]
        [DisplayName("CNPJ")]
        public long NR_CNPJ { get; set; }

        [DisplayName("Telefone(s)")]
        public List<string> NR_TELEFONES { get; set; }

        [DisplayName("Endereço")]
        public EnderecoDTO ENDERECO { get; set; }
    }
}
