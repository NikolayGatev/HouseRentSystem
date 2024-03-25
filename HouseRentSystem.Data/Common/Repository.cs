using Microsoft.EntityFrameworkCore;

namespace HouseRentSystem.Data.Common
{
    public class Repository : IRepozitory
    {
        private readonly DbContext context;

        public Repository(HouseRentingDbContext context)
        {
            this.context = context;
        }

        private DbSet<T> DbSet<T>()
            where T : class
        {
            return this.context.Set<T>();
        }

        public async Task AddAsync<T>(T entity)
            where T : class
        {
            await this.DbSet<T>().AddAsync(entity);
        }

        public IQueryable<T> All<T>()
            where T : class
        {
            return this.DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>()
            where T : class
        {
            return this.DbSet<T>()
                .AsNoTracking();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id)
            where T : class
        {
            return await this.DbSet<T>().FindAsync(id);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await this.GetByIdAsync<T>(id);

            if (entity != null)
            {
                this.DbSet<T>().Remove(entity);
            }
        }
    }
}
