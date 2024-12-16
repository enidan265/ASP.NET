namespace DevSpot.Repositories
{
    public interface IRepository<T> where T : class
    {
        // CRUD - R 
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        // CRUD - C
        Task AddAsync(T entity);
        
        // CRUD - U
        Task UpdateAsync(T entity);

        // CRUD - D  
        Task DeleteAsync(int id);

    }
}
