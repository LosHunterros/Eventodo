using AutoMapper;
using Eventodo.Domain;
using Eventodo.Domain.Modules;
using Eventodo.DTOs;

namespace Eventodo.Configurations.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<Module, ModuleDto>()
                .Include<ModuleAgenda, ModuleAgendaDto>()
                .Include<ModuleGalery, ModuleGaleryDto>();
            CreateMap<ModuleAgenda, ModuleAgendaDto>();
            CreateMap<ModuleGalery, ModuleGaleryDto>();
        }
    }
}
