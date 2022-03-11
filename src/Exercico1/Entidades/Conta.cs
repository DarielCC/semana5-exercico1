using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public class Conta : EntidadeBase
    {
        public string Descricao { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal SaldoInicial { get; private set; }
        public IList<Transacao> Transacoes { get; private set; }

        public Conta(string id, string descricao, string numeroConta, decimal saldoInicial) : base(id)
        {
            Descricao = descricao;
            NumeroConta = numeroConta;
            SaldoInicial = saldoInicial;

            Transacoes = new List<Transacao>();
        }

        public decimal CalcularTotal(TipoCategoriaEnum tipoCategoria, DateOnly data)
            => Transacoes
                .Where(trans => trans.Data <= data && trans.Categoria.TipoCategoria == tipoCategoria)
                .Sum(trans => trans.Valor);

        public virtual decimal CalcularSaldo(DateOnly data)
        {
            IEnumerable<Transacao>? transacoes = Transacoes.Where(trans => trans.Data <= data);

            return SaldoInicial +
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Receita).Sum(trans => trans.Valor) -
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Despesa).Sum(trans => trans.Valor);
        }
    }
}
