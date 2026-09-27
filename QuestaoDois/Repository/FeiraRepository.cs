using QuestaoDois.Models;

namespace QuestaoDois.Repository
{
    public class FeiraRepository : IFeiraRepository
    {
        private static List<Projeto> _projetos = new List<Projeto>();
        private static List<Visita> _visitas = new List<Visita>();

        public void CadastrarProjeto(Projeto projeto)
        {
            _projetos.Add(projeto);
        }

        public List<Projeto> ListarProjetos()
        {
            return _projetos;
        }

        public Projeto ObterProjetoPorNumero(int numero)
        {
            return _projetos.FirstOrDefault(p => p.Numero == numero);
        }

        public void RegistrarVisita(Visita visita)
        {
            _visitas.Add(visita);
        }

        public List<Visita> ObterVisitasPorProjeto(int numero)
        {
            return _visitas.Where(v => v.NumeroProjeto == numero).ToList();
        }
    }
}
