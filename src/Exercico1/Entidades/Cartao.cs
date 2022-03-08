﻿using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public abstract class Cartao
    {
        public string Nome { get; private set; }
        public string Numero { get; private set; }
        public int CodigoSeguranca { get; private set; }
        public DateOnly DataValidade { get; private set; }
        public BandeiraEnum Bandeira { get; private set; }

        protected Cartao() { }

        protected Cartao(string nome, string numero, int codigoSeguranca,
                      DateOnly dataValidade, BandeiraEnum bandeira)
        {
            Nome = nome;
            Numero = numero;
            CodigoSeguranca = codigoSeguranca;
            DataValidade = dataValidade;
            Bandeira = bandeira;
        }

        public virtual TipoCartaoEnum RetornarTipoCartao() => TipoCartaoEnum.Credito;

        public abstract decimal CalcularSaldo(decimal valor);
    }
}