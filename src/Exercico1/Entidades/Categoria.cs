using Semana5.Exercico1.Enums;

namespace Semana5.Exercico1.Entidades
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; private set; }
        public TipoCategoriaEnum TipoCategoria { get; private set; }

        public Categoria(string id, string nome, TipoCategoriaEnum tipoCategoria) : base(id)
        {
            Nome = nome;
            TipoCategoria = tipoCategoria;
        }
    }
}
