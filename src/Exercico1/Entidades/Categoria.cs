using Semana5.Exercico1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Entidades
{
    public class Categoria
    {
        public string Nome { get; private set; }
        public TipoCategoriaEnum TipoCategoria { get; private set; }

        public Categoria(string nome, TipoCategoriaEnum tipoCategoria)
        {
            Nome = nome;
            TipoCategoria = tipoCategoria;
        }
    }
}
