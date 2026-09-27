using System.ComponentModel.DataAnnotations;

namespace QuestaoDois.Models
{
    public class Visita
    {
        [Required(ErrorMessage = "RA é obrigatório")]
        public string RA { get; set; }

        public DateTime DataVisita { get; set; }

        public int NumeroProjeto { get; set; }

        [Range(0, 5, ErrorMessage = "Nota deve ser entre 0 e 5")]
        public double Nota { get; set; }
    }
}