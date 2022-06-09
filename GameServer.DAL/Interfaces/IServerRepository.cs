using GameServer.Domain.Entity.Dto;

namespace GameServer.DAL.Interfaces
{
    public interface IServerRepository : IBaseRepository<ServerDto>
    {
        Task<bool> DeleteAsync(string uniqAddress);
        Task<ServerDto> GetByIdAsync(Guid id);
        Task<ServerDto> GetByIdAsync(string uniqAddress);
    }
}
