using System.ComponentModel.DataAnnotations;

namespace QuestaoUm.Models
{
    public class Voto
    {
        [Required(ErrorMessage = "RA é obrigatório")]
        public string RA { get; set; }

        public DateTime DataVoto { get; set; }

        public int NumeroCandidato { get; set; }
    }
}