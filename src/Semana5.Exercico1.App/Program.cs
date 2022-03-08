// See https://aka.ms/new-console-template for more information
using Semana5.Exercico1.Entidades;
using Semana5.Exercico1.Enums;

Console.WriteLine("Hello, World!");


var cartaoCredito = new CartaoCredito("Dariel Credito", "15128356127435164", 123, new DateOnly(2022, 11, 1), BandeiraEnum.Cielo, 1500);
var cartaoAlimentacao = new CartaoAlimentacao("Dariel Alimentação", "15128356127435164", 123, new DateOnly(2022, 10, 1), BandeiraEnum.Visa, new DateOnly(2022, 3, 1), 450);

Console.WriteLine($"Cartão: {cartaoCredito.Nome}, No: {cartaoCredito.Numero}, DataValidade: {cartaoCredito.DataValidade:dd-MM-yy}, Limite: {cartaoCredito.Limite}, Saldo: {cartaoCredito.CalcularSaldo(150)}, Tipo: {cartaoCredito.RetornarTipoCartao()}");
Console.WriteLine($"Cartão: {cartaoAlimentacao.Nome}, No: {cartaoAlimentacao.Numero}, DataValidade: {cartaoAlimentacao.DataValidade:dd-MM-yy}, DataRecarga: {cartaoAlimentacao.DataRecarga:dd-MM-yy}, ValorRecarga: {cartaoAlimentacao.ValorRecarga:N2}, Saldo: {cartaoAlimentacao.CalcularSaldo(200)}, Tipo: {cartaoAlimentacao.RetornarTipoCartao()}");

