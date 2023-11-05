using AutoMapper;

namespace ThAmCo.Profiles.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //CreateMap<Collector, CollectorHealthDTO>()
            //    .ForMember(dest => dest.HostName, opt => opt.MapFrom(src => src.HostName))
            //    .ForMember(dest => dest.IPAddress, opt => opt.MapFrom(src => src.IPAddress))
            //    .ForMember(dest => dest.DateLastTaken, opt => opt.MapFrom(src => src.LastSeen))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsAirgapped ? DeviceStatus.Standalone : src.LastSeen < DateTime.Now.AddHours(-24) ? DeviceStatus.LostCommunication : DeviceStatus.Ok))
            //    .ReverseMap();
        }
    }
}
