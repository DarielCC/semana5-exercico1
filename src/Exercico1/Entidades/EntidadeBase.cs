namespace Semana5.Exercico1.Entidades
{
    public abstract class EntidadeBase
    {
        public string Id { get; private set; }

        protected EntidadeBase() { }

        protected EntidadeBase(string id) => Id = id;
    }
}
