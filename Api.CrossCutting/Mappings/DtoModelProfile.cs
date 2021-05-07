using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoModelProfile: Profile
    {
        public DtoModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap(); /*ReverseMap converte vice e versa*/
        }
    }
}
