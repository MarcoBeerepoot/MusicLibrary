using TR.MusicLibrary.DL.Interfaces;

namespace TR.MusicLibrary.DL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext DbContext { get; }

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
