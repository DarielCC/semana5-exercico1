using Semana5.Exercico1.Entidades;

namespace Semana5.Exercico1.Interfaces
{
    public interface IMovimentacaoWrite
    {
        void AdicionarConta(Conta conta);
        void AdicionarTransacao(string numeroConta, Transacao transacao);
        void ApagarConta(string numeroConta);
    }
}
