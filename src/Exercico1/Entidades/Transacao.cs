using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Entidades
{
    public class Transacao
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateOnly Data { get; private set; }
        public Categoria Categoria { get; private set; }

        public Transacao(string descricao, decimal valor, DateOnly data, Categoria categoria)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Categoria = categoria;
        }
    }
}
