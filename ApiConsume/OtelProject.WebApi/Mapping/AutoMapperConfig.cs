using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace OtelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //dto ile entity burada bağlanır
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
            CreateMap<RoomUpdateDto, Room>().ReverseMap();//reversemap dersek tam tersi durum da geçerli demek
            CreateMap<RoomUpdateDto, Room>().ReverseMap();//reversemap dersek tam tersi durum da geçerli demek
        }
    }
}
