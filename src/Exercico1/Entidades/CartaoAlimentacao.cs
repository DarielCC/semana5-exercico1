using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public class CartaoAlimentacao : Cartao
    {
        public DateOnly DataRecarga { get; private set; }
        public decimal ValorRecarga { get; private set; }

        public CartaoAlimentacao() { }

        public CartaoAlimentacao(string nome, string numero, int codigoSeguranca,
                      DateOnly dataValidade, BandeiraEnum bandeira,
                      DateOnly dataRecarga, decimal valorRecarga)
            : base(nome, numero, codigoSeguranca, dataValidade, bandeira)
        {
            DataRecarga = dataRecarga;

            if(valorRecarga < 0)
            {
                throw new ArgumentException("Valor não pode ser zero");
            }
            ValorRecarga = valorRecarga;
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

        public override decimal CalcularSaldo(decimal valor) => ValorRecarga - valor;
    }
}