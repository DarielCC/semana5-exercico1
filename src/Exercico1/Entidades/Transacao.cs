namespace Semana5.Exercico1.Entidades
{
    public class Transacao : EntidadeBase
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateOnly Data { get; private set; }
        public Categoria Categoria { get; private set; }

        public Transacao(string id, string descricao, decimal valor, DateOnly data, Categoria categoria) : base(id)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Categoria = categoria;
        }
    }
}
