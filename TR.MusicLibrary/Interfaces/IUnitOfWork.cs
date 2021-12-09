namespace TR.MusicLibrary.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
