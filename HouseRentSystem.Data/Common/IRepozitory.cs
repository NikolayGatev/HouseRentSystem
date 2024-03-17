namespace HouseRentSystem.Data.Common
{
    public interface IRepozitory
    {
        IQueryable<T> All<T>() 
            where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id)
            where T : class;

        public void Delete<T>(T entity)
            where T : class;
    }
}
