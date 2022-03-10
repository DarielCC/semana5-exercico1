using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public class CartaoCredito : Cartao
    {
        public IList<TransacaoCredito> Transacoes { get; private set; }

        public decimal Limite { get; private set; }

        public CartaoCredito(string nome, string numero, int codigoSeguranca,
                      DateOnly dataValidade, BandeiraEnum bandeira, decimal limite)
             : base(nome, numero, codigoSeguranca, dataValidade, bandeira)
        {
            Limite = limite;
            Transacoes = new List<TransacaoCredito>();
        }

        public override decimal CalcularSaldo(DateOnly data)
        {
            var transacoes = Transacoes.Where(trans => trans.Data <= data);

            return Limite +
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Receita).Sum(trans => trans.Valor) -
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Despesa).Sum(trans => trans.Valor);
        }
    }
}