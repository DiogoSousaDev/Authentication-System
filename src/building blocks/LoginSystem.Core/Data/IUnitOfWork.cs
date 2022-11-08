namespace LoginSystem.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }

}
