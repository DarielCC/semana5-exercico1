using Semana5.Exercico1.Entidades;

namespace Semana5.Exercico1.Models
{
    public class TransacoesPorCategoriaModel
    {
        public Categoria Categoria { get; set; }
        public IEnumerable<Transacao> Transacoes { get; set; }
    }
}
