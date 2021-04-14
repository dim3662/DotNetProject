using AutoMapper;
using DotNetProject.DotNetProjectDataAccess.Entities;
using DotNetProject.Models;
using DotNetProjectClient.DTO;
using DotNetProjectClient.Request.Create;
using DotNetProjectClient.Request.Update;

namespace DotNetProjectWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Person, DotNetProject.Person>();
            this.CreateMap<Secret, DotNetProject.Secret>();
            this.CreateMap<Message, DotNetProject.Message>();
            this.CreateMap<DotNetProject.Person, PersonDTO>();
            this.CreateMap<DotNetProject.Secret, SecretDTO>();
            this.CreateMap<DotNetProject.Message,MessageDTO>();
            this.CreateMap<PersonCreateDTO,PersonUpdateModel>();
            this.CreateMap<SecretCreateDTO, SecretUpdateModel>();
            this.CreateMap<PersonUpdateDTO, PersonUpdateModel>();
            this.CreateMap<SecretUpdateDTO, SecretUpdateModel>();
            this.CreateMap<SecretUpdateModel, Secret>();
            this.CreateMap<PersonUpdateModel, Person>();
        }
    }
}