using QuestaoUm.Models;

namespace QuestaoUm.Repository
{
    public interface IEleicaoRepository
    {
        public void CadastrarCandidato(Candidato candidato);
        public List<Candidato> ListarCandidatos();
        public Candidato ObterCandidatoPorNumero(int numero);
        public void RegistrarVoto(Voto voto);
        public List<Voto> ObterVotosPorCandidato(int numero);
    }
}