using Semana5.Exercico1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Entidades
{
    public class Conta
    {
        public string Descricao { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal SaldoInicial { get; private set; }
        public IList<Transacao> Transacoes { get; private set; }

        protected Conta(string descricao, string numeroConta, decimal saldoInicial)
        {
            Descricao = descricao;
            NumeroConta = numeroConta;
            SaldoInicial = saldoInicial;

            Transacoes = new List<Transacao>();
        }

        public decimal CalcularSaldo(DateOnly data)
        {
            var transacoes = Transacoes.Where(trans => trans.Data <= data);

            return SaldoInicial +
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Receita).Sum(trans => trans.Valor) -
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Despesa).Sum(trans => trans.Valor);
        }

        public void AdicionarTransacao(Transacao transacao) => Transacoes.Add(transacao);
    }
}
