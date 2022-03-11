using Microsoft.Extensions.DependencyInjection;
using Semana5.Exercico1.App;
using Semana5.Exercico1.Entidades;
using Semana5.Exercico1.Enums;
using Semana5.Exercico1.Interfaces;

Console.WriteLine("Minha aplicação financeira!");
Console.WriteLine("----------------------------------------");

#region Resolvendo Injeção de Dependencia

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<ICategoriaRepository, CategoriaRepository>();
serviceCollection.AddScoped<IMovimentacaoContaRepository, MovimentacaoContaRepository>();
serviceCollection.AddScoped<IMovimentacaoCartaoAlimentacaoRepository, MovimentacaoCartaoAlimentacaoRepository>();
var serviceProvider = serviceCollection.BuildServiceProvider();
var _movimentacaoContaRepository = serviceProvider.GetService<IMovimentacaoContaRepository>();
var _movimentacaoCartaoRepository = serviceProvider.GetService<IMovimentacaoCartaoAlimentacaoRepository>();
var _categoriaRepository = serviceProvider.GetService<ICategoriaRepository>();

var _aplicacaoFinanceira = new AplicacaoFinanceira(
                _movimentacaoContaRepository,
                _movimentacaoCartaoRepository,
                _categoriaRepository);

#endregion

#region Funcionalidades Categoria

Console.WriteLine("Funcionalidades Categoria");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("1", "Salário", TipoCategoriaEnum.Receita);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("2", "Aluguel", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("3", "Condomínio", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("4", "Combustível", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("5", "Compras", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("6", "Limpesa", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("7", "Investimentos", TipoCategoriaEnum.Receita);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("8", "Supermercado", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

#endregion

#region Funcionalidades Conta

Console.WriteLine("Funcionalidades Conta");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarConta("1", "Conta NuBank", "12344", 1000);

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarConta("2", "Conta Poupança", "45674", 13000, 3);

_aplicacaoFinanceira.RetornarSaldoConta("2", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("1", "Cobro salário", 1500, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "1", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("2", "Pagamento aluguel", 500, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "2", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("3", "Compra mercado", 100, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "3", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("4", "Compra mercado", 250, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "3", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("5", "Guardando dinheiro", 1500, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "7", "2");

_aplicacaoFinanceira.RetornarSaldoConta("2", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

Console.WriteLine("Funcionalidades Transação");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.RetornarTransacoesPorCategorias("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

#endregion

#region Funcionalidades Cartão

Console.WriteLine("Funcionalidades Cartão");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCartao("1", "Dariel Corrales", "12344", 123, DateOnly.FromDateTime(DateTime.Now.AddDays(100)), BandeiraEnum.MasterCard, DateOnly.FromDateTime(DateTime.Now), 580);

_aplicacaoFinanceira.RetornarSaldoCartao("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoCartao("1", "Compra Big Iguatemi", 210, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "8", "1");

_aplicacaoFinanceira.RetornarSaldoCartao("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoCartao("2", "Compra Almoço", 35, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "8", "1");

_aplicacaoFinanceira.RetornarSaldoCartao("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoCartao("3", "Compra pizza", 59, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "8", "1");

_aplicacaoFinanceira.RetornarSaldoCartao("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

#endregion