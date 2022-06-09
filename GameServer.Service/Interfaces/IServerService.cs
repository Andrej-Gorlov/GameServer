using GameServer.Domain.Entity.Dto;
using GameServer.Domain.Response;

namespace GameServer.Service.Interfaces
{
    public interface IServerService : IBaseService<ServerDto>
    {
        Task<IBaseResponse<bool>> DeleteServiceAsync(string uniqAddress);
        Task<IBaseResponse<ServerDto>> GetByIdAsync(Guid id);
        Task<IBaseResponse<ServerDto>> GetByIdAsync(string uniqAddress);
    }
}
