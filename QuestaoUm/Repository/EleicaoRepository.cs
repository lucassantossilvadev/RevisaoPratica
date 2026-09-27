using QuestaoUm.Models;

namespace QuestaoUm.Repository
{
    public class EleicaoRepository : IEleicaoRepository
    {
        private static List<Candidato> _candidatos = new List<Candidato>();
        private static List<Voto> _votos = new List<Voto>();

        public void CadastrarCandidato(Candidato candidato)
        {
            _candidatos.Add(candidato);
        }

        public List<Candidato> ListarCandidatos()
        {
            return _candidatos;
        }

        public Candidato ObterCandidatoPorNumero(int numero)
        {
            return _candidatos.FirstOrDefault(c => c.Numero == numero);
        }

        public void RegistrarVoto(Voto voto)
        {
            _votos.Add(voto);
        }

        public List<Voto> ObterVotosPorCandidato(int numero)
        {
            return _votos.Where(v => v.NumeroCandidato == numero).ToList();
        }
    }
}