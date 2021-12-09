namespace TR.MusicLibrary.DL.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
