using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.Interfaces;

namespace TR.MusicLibrary.DL
{
    /// <summary>
    /// Generic repository that contains methods for commonly used database queries on business entities.
    /// </summary>
    /// <typeparam name="T">The type of the businessentity</typeparam>
    public class RepositoryBase<T>
        where T : IHasKey
    {
        public RepositoryBase(DbContext context)
        {
            DbSet = context.Set<T>();
        }

        protected DbSet<T> DbSet { get; }

        public Task<T> Get(int id)
        {
            return DbSet.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task Add(T entity)
        {
            DbSet.Add(entity);
            return Task.CompletedTask;
        }
    }
}
