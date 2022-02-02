using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportsX.DTOs
{
    public class EnderecoDTO
    {
        [JsonIgnore]
        public int ID_ENDERECO { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório!")]
        [MinLength(5)]
        [MaxLength(12)]
        [DisplayName("CEP")]
        public string NR_CEP { get; set; }
    }
}
