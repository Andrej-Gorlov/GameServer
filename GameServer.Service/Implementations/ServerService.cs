using GameServer.DAL.Interfaces;
using GameServer.Domain.Entity.Dto;
using GameServer.Domain.Response;
using GameServer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Service.Implementations
{
    public class ServerService : IServerService
    {
        private IServerRepository _serverRep;
        public ServerService(IServerRepository serverRep)
        {
            _serverRep = serverRep;
        }

        public async Task<IBaseResponse<ServerDto>> CreateServiceAsync(ServerDto modelDto)
        {
            var servers = await _serverRep.GetAsync();
            if (servers.FirstOrDefault(x=>x.UniqAddress == modelDto.UniqAddress) != null)
            {
                throw new Exception("Попытка добавить объект, который уже существует в хранилище.");
            }
            var baseResponse = new BaseResponse<ServerDto>();
            var server = await _serverRep.CreateAsync(modelDto);
            if (server != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = server;
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(string uniqAddress)
        {
            var baseResponse = new BaseResponse<bool>();
            bool IsSuccess = await _serverRep.DeleteAsync(uniqAddress);
            if (IsSuccess)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = IsSuccess;
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(Guid id)
        {
            var baseResponse = new BaseResponse<bool>();
            bool IsSuccess = await _serverRep.DeleteAsync(id);
            if (IsSuccess)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = IsSuccess;
            return baseResponse;
        }
        public async Task<IBaseResponse<ServerDto>> GetByIdAsync(Guid id)
        {
            var baseResponse = new BaseResponse<ServerDto>();
            var book = await _serverRep.GetByIdAsync(id);
            if (book != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = book;
            return baseResponse;
        }
        public async Task<IBaseResponse<ServerDto>> GetByIdAsync(string uniqAddress)
        {
            var baseResponse = new BaseResponse<ServerDto>();
            var book = await _serverRep.GetByIdAsync(uniqAddress);
            if (book != null)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = book;
            return baseResponse;
        }
        public async Task<IBaseResponse<IEnumerable<ServerDto>>> GetServiceAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<ServerDto>>();
            var server = await _serverRep.GetAsync();
            if (server.Count() != 0)
            {
                baseResponse.IsSuccess = true;
            }
            baseResponse.Result = server;
            return baseResponse;
        }
        public async Task<IBaseResponse<ServerDto>> UpdateServiceAsync(ServerDto modelDto)
        {
            var servers = await _serverRep.GetAsync();
            if (servers.FirstOrDefault(x => x.UniqAddress == modelDto.UniqAddress).MaxPlayers < modelDto.CurrentPlayers)
            {
                // переносим на сервак на котором меньше всего играков 

            }
            var baseResponse = new BaseResponse<ServerDto>();
            ServerDto server = await _serverRep.UpdateAsync(modelDto);
            baseResponse.IsSuccess = true;
            baseResponse.Result = server;
            return baseResponse;
        }
    }
}
