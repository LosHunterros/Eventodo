using AutoMapper;
using Eventodo.Domain;
using Eventodo.DTOs;

namespace Eventodo.Configurations.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
