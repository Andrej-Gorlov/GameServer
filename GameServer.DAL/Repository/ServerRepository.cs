using AutoMapper;
using GameServer.DAL.Interfaces;
using GameServer.Domain.Entity;
using GameServer.Domain.Entity.Dto;
using Microsoft.EntityFrameworkCore;

namespace GameServer.DAL.Repository
{
    public class ServerRepository : IServerRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public ServerRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ServerDto> CreateAsync(ServerDto modelDto)
        {
            Server server = _mapper.Map<ServerDto, Server>(modelDto);
            _db.Servers.Add(server);
            await _db.SaveChangesAsync();
            return _mapper.Map<Server, ServerDto>(server);
        }
        public async Task<bool> DeleteAsync(string uniqAddress)
        {
            try
            {
                Server? server = await _db.Servers.FirstOrDefaultAsync(x => x.UniqAddress == uniqAddress);
                if (server is null)
                {
                    return false;
                }
                _db.Servers.Remove(server);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                Server? server = await _db.Servers.FirstOrDefaultAsync(x => x.ServerId == id);
                if (server is null)
                {
                    return false;
                }
                _db.Servers.Remove(server);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<IEnumerable<ServerDto>> GetAsync() =>

            _mapper.Map<IEnumerable<ServerDto>>(await _db.Servers.ToListAsync());

        public async Task<ServerDto> GetByIdAsync(Guid id) =>

            _mapper.Map<ServerDto>(await _db.Servers.FirstOrDefaultAsync(x => x.ServerId == id));

        public async Task<ServerDto> GetByIdAsync(string uniqAddress) =>

            _mapper.Map<ServerDto>(await _db.Servers.FirstOrDefaultAsync(x => x.UniqAddress == uniqAddress));

        public async Task<ServerDto> UpdateAsync(ServerDto modelDto)
        {
            Server server = _mapper.Map<ServerDto, Server>(modelDto);
            if (await _db.Servers.AsNoTracking().FirstOrDefaultAsync(
                x => x.UniqAddress == modelDto.UniqAddress && x.ServerId == modelDto.ServerId) is null)
            {
                throw new NullReferenceException("Попытка обновить объект, которого нет в хранилище.");
            }
            _db.Servers.Update(server);
            await _db.SaveChangesAsync();
            return _mapper.Map<Server, ServerDto>(server);
        }
    }
}
