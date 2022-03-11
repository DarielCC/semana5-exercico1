using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public abstract class Cartao : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Numero { get; private set; }
        public int CodigoSeguranca { get; private set; }
        public DateOnly DataValidade { get; private set; }
        public BandeiraEnum Bandeira { get; private set; }

        protected Cartao() { }

        protected Cartao(string id, string nome, string numero, int codigoSeguranca,
                      DateOnly dataValidade, BandeiraEnum bandeira) : base(id)
        {
            Nome = nome;
            Numero = numero;
            CodigoSeguranca = codigoSeguranca;
            DataValidade = dataValidade;
            Bandeira = bandeira;
        }

        protected Cartao(string nome, string numero)
        {
            Nome = nome;
            Numero = numero;
        }

        public virtual TipoCartaoEnum RetornarTipoCartao() => TipoCartaoEnum.Credito;

        public abstract decimal CalcularSaldo(DateOnly data);
    }
}