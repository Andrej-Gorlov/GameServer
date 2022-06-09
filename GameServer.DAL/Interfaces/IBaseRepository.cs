namespace GameServer.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> CreateAsync(T modelDto);
        Task<bool> DeleteAsync(Guid id);
        Task<T> UpdateAsync(T modelDto);
    }
}
