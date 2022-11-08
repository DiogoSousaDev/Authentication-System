using LoginSystem.Core.DomainObjects;

namespace LoginSystem.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

}
