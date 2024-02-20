using AutoMapper;
using Eventodo.Core;
using Eventodo.Core.Modules;
using Eventodo.Aplication.DTOs;
using Eventodo.Aplication.DTOs.Modules;

namespace Eventodo.Aplication.Profiles.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDTO>();

            CreateMap<Module, ModuleDTO>()
                .Include<ModuleAgenda, ModuleAgendaDTO>()
                .Include<ModuleGalery, ModuleGaleryDTO>();

            CreateMap<ModuleAgenda, ModuleAgendaDTO>();
            CreateMap<ModuleGalery, ModuleGaleryDTO>();

            CreateMap<UserRegisterDTO, User>();
        }
    }
}
