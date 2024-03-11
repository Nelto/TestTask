namespace TestTask.Model.Abstract
{
    public interface IRepos<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
