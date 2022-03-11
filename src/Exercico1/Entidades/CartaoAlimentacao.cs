using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public class CartaoAlimentacao : Cartao
    {
        public DateOnly DataRecarga { get; private set; }
        public decimal ValorRecarga { get; private set; }
        public IList<Transacao> Transacoes { get; private set; }

        public CartaoAlimentacao() { }

        public CartaoAlimentacao(string id, string nome, string numero, int codigoSeguranca,
                      DateOnly dataValidade, BandeiraEnum bandeira,
                      DateOnly dataRecarga, decimal valorRecarga)
            : base(id, nome, numero, codigoSeguranca, dataValidade, bandeira)
        {
            DataRecarga = dataRecarga;

            if (valorRecarga < 0)
            {
                throw new ArgumentException("Valor não pode ser zero");
            }
            ValorRecarga = valorRecarga;

            Transacoes = new List<Transacao>();
        }

        public CartaoAlimentacao(string nome, string numero, decimal valorRecarga)
            : base(nome, numero)
        {
            if (valorRecarga < 0)
            {
                throw new ArgumentException("Valor não pode ser zero");
            }
            ValorRecarga = valorRecarga;
        }

        public override TipoCartaoEnum RetornarTipoCartao() => TipoCartaoEnum.Alimentacao;

        public override decimal CalcularSaldo(DateOnly data)
        {
            IEnumerable<Transacao>? transacoes = Transacoes.Where(trans => trans.Data <= data);

            return ValorRecarga +
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Receita).Sum(trans => trans.Valor) -
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Despesa).Sum(trans => trans.Valor);
        }
    }
}