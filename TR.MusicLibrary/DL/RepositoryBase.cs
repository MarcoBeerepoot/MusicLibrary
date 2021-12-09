using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Interfaces;

namespace TR.MusicLibrary.DL
{
    /// <summary>
    /// Generic repository that contains methods for commonly used database queries on business entities.
    /// </summary>
    /// <typeparam name="T">The type of the businessentity</typeparam>
    public class RepositoryBase<T> : IRepository<T>
        where T : IHasKey
    {
        public RepositoryBase(DbContext context)
        {
            DbSet = context.Set<T>();
        }

        protected DbSet<T> DbSet { get; }

        public virtual Task<T> Get(int id)
        {
            return DbSet.FirstOrDefaultAsync(a => a.Id == id);
        }

        public virtual Task Add(T entity)
        {
            DbSet.Add(entity);
            return Task.CompletedTask;
        }
    }
}
