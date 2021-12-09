namespace TR.MusicLibrary.DL.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task Add(T entity);
    }
}
