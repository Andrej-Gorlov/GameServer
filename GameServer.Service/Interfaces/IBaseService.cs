using GameServer.Domain.Response;

namespace GameServer.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<IBaseResponse<IEnumerable<T>>> GetServiceAsync();
        Task<IBaseResponse<T>> CreateServiceAsync(T modelDto);
        Task<IBaseResponse<T>> UpdateServiceAsync(T modelDto);
        Task<IBaseResponse<bool>> DeleteServiceAsync(Guid id);
    }
}
