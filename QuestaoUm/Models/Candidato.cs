using System.ComponentModel.DataAnnotations;

namespace QuestaoUm.Models
{
    public class Candidato
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Range(1, 8, ErrorMessage = "Turma deve ser entre 1 e 8")]
        public int Turma { get; set; }

        [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        public string DescricaoProposta { get; set; }

        [Range(10, 99, ErrorMessage = "Número deve ser entre 10 e 99")]
        public int Numero { get; set; }
    }
}