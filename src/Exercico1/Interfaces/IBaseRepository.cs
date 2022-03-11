using Semana5.Exercico1.Entidades;

namespace Semana5.Exercico1.Interfaces
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        public void AdicionarElemento(T elemento);

        public void ApagarElemento(string id);

        public T RetornarElemento(string id);
    }
}
