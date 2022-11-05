using AutoMapper;
using MudServer.DataAccess.Models;
using MudServer.ViewModels;

namespace MudServer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookView, Book>().ReverseMap();
            CreateMap<UserView, User>().ReverseMap();
        }
    }
}
