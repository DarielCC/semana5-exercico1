using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public class CartaoCredito : Cartao
    {
        public decimal Limite { get; private set; }

        public CartaoCredito(string nome, string numero, int codigoSeguranca,
                      DateOnly dataValidade, BandeiraEnum bandeira, decimal limite)
             : base(nome, numero, codigoSeguranca, dataValidade, bandeira) =>
            Limite = limite;

        public override decimal CalcularSaldo(decimal valor) => Limite - valor;
    }
}