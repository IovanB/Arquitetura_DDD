using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsyinc(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = mapper.Map<UserModel>(user); /*Converter para UserModel*/
            var entity = mapper.Map<UserEntity>(model); /*Converter para entidade para ir para o banco*/
            var result = await _repository.InsertAsync(entity); /*Passando no banco de dados*/

            return mapper.Map<UserDtoCreateResult>(result);
            
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = mapper.Map<UserModel>(user);
            var entity = mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
