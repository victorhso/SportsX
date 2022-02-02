using System.Text.Json.Serialization;

namespace SportsX.DTOs
{
    public class TelefoneDTO
    {
        [JsonIgnore]
        public int ID_TELEFONE { get; private set; }
        public string NR_TELEFONE { get; private set; }
    }
}
