using Semana5.Exercico1.Entidades;
using Semana5.Exercico1.Enums;
using Semana5.Exercico1.Interfaces;

namespace Semana5.Exercico1.App
{
    public class AplicacaoFinanceira
    {
        private readonly IMovimentacaoContaRepository _movimentacaoContaRepository;
        private readonly IMovimentacaoCartaoAlimentacaoRepository _movimentacaoCartaoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public AplicacaoFinanceira(IMovimentacaoContaRepository movimentacaoContaRepository,
                                   IMovimentacaoCartaoAlimentacaoRepository movimentacaoCartaoRepository,
                                   ICategoriaRepository categoriaRepository)
        {
            _movimentacaoContaRepository = movimentacaoContaRepository;
            _movimentacaoCartaoRepository = movimentacaoCartaoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public void CriarCategoria(string id, string descricao, TipoCategoriaEnum tipo)
        {
            Console.WriteLine($"Criando categoria {descricao} do tipo {tipo}");

            Categoria? categoria = new Categoria(id, descricao, tipo);
            _categoriaRepository.AdicionarElemento(categoria);

            Console.WriteLine($"Categoria {descricao} criada com sucesso");
        }

        public void CriarConta(string id, string descricao, string numero, decimal saldoinicial, decimal rendimento = 0)
        {
            Console.WriteLine($"Criando conta numero {numero}");

            Conta? conta = rendimento > 0 ? new ContaPoupanca(id, descricao, numero, saldoinicial, rendimento)
                                       : new Conta(id, descricao, numero, saldoinicial);
            _movimentacaoContaRepository.AdicionarElemento(conta);

            Console.WriteLine($"Conta numero {numero} criada com sucesso");
        }

        public void AdicionarTransacaoConta(string id, string descricao, decimal valor, DateOnly data, string categoriaId, string contaId)
        {
            Transacao? transacao = AdicionarTransacaoConta(id, descricao, valor, data, categoriaId);

            _movimentacaoContaRepository.AdicionarTransacao(contaId, transacao);
        }

        public void RetornarSaldoConta(string id, DateOnly data)
        {
            Conta? conta = _movimentacaoContaRepository.RetornarElemento(id);
            decimal saldo = _movimentacaoContaRepository.RetornarSaldoConta(id, data);

            Console.WriteLine($"O saldo de minha conta {conta.Descricao} é de R${saldo:N2}");
        }

        public void RetornarTransacoesPorCategorias(string contaId, DateOnly data)
        {
            IEnumerable<Models.TransacoesPorCategoriaModel>? transacoesPorCategoria = _movimentacaoContaRepository.RetornarTransacoesAgrupadasPorCategorias(contaId, data);

            foreach (Models.TransacoesPorCategoriaModel? transacaoPorCategoria in transacoesPorCategoria)
            {
                Console.WriteLine($"A categoria {transacaoPorCategoria.Categoria.Nome} tem {transacaoPorCategoria.Transacoes.Count()} transações");

                foreach (Transacao? transacaoCat in transacaoPorCategoria.Transacoes)
                {
                    Console.WriteLine($"Transação: {transacaoCat.Descricao}, Valor: R${transacaoCat.Valor}");
                }
            }
        }

        public void CriarCartao(string id, string nome, string numero, int codigoSeguranca, DateOnly dataValidade, BandeiraEnum bandeira, DateOnly dataRecarga, decimal valorRecarga)
        {
            Console.WriteLine($"Criando cartão numero {numero}");

            CartaoAlimentacao? cartao = new CartaoAlimentacao(id, nome, numero, codigoSeguranca, dataValidade, bandeira, dataRecarga, valorRecarga);
            _movimentacaoCartaoRepository.AdicionarElemento(cartao);

            Console.WriteLine($"Cartão numero {numero} criado com sucesso");
        }

        public void AdicionarTransacaoCartao(string id, string descricao, decimal valor, DateOnly data, string categoriaId, string cartaoId)
        {
            Transacao? transacao = AdicionarTransacaoConta(id, descricao, valor, data, categoriaId);

            _movimentacaoCartaoRepository.AdicionarTransacao(cartaoId, transacao);
        }

        public void RetornarSaldoCartao(string id, DateOnly data)
        {
            CartaoAlimentacao? cartao = _movimentacaoCartaoRepository.RetornarElemento(id);
            decimal saldo = _movimentacaoCartaoRepository.RetornarSaldoCartao(id, data);

            Console.WriteLine($"O saldo de meu cartão {cartao.Numero} é de R${saldo:N2}");
        }

        private Transacao AdicionarTransacaoConta(string id, string descricao, decimal valor, DateOnly data, string categoriaId)
        {
            Categoria? categoria = _categoriaRepository.RetornarElemento(categoriaId);

            Console.WriteLine($"Criando um {categoria.TipoCategoria} no valor de R${valor:N2} - Descrição: {descricao} ");

            Transacao? transacao = new Transacao(id, descricao, valor, data, categoria);

            Console.WriteLine($"{categoria.TipoCategoria} no valor de R${valor:N2} - Descrição: {descricao} criado com sucesso");

            return transacao;
        }
    }
}
