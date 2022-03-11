namespace Semana5.Exercico1.Entidades
{
    public class ContaPoupanca : Conta
    {
        public decimal Rendimento { get; private set; }

        public ContaPoupanca(string id, string descricao, string numeroConta, decimal saldoInicial, decimal rendimento)
                      : base(id, descricao, numeroConta, saldoInicial)
            => Rendimento = rendimento;

        public override decimal CalcularSaldo(DateOnly data)
        {
            decimal saldo = base.CalcularSaldo(data);

            return saldo + (saldo * Rendimento / 100);
        }
    }
}
