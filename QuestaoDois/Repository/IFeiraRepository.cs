using QuestaoDois.Models;

public interface IFeiraRepository
{
    public void CadastrarProjeto(Projeto projeto);
    public List<Projeto> ListarProjetos();
    public Projeto ObterProjetoPorNumero(int numero);
    public void RegistrarVisita(Visita visita);
    public List<Visita> ObterVisitasPorProjeto(int numero);
}