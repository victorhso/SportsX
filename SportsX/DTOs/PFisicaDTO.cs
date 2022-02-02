using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportsX.DTOs
{
    public class PFisicaDTO
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatória!")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string DS_NOME { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório!")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        public string DS_EMAIL { get; set; }

        [Required(ErrorMessage = "Classificação obrigatório!")]
        [DisplayName("Classificação")]
        public bool DS_CLASSIFICACAO { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        [DisplayName("CPF")]
        public long NR_CPF { get; set; }

        [DisplayName("Telefone(s)")]
        public List<string> NR_TELEFONES { get; set; }

        [DisplayName("Endereço")]
        public EnderecoDTO ENDERECO { get; set; }
    }
}
