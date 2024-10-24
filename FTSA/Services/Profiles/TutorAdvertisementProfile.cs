using AutoMapper;
using Entities.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class TutorAdvertisementProfile : Profile
    {
        public TutorAdvertisementProfile() 
        {
            CreateMap<RequestTutorAdvertisement, TutorAdvertisement>()
                .ForMember(dest => dest.AdvertisementId, opt => opt.MapFrom(src => src.AdvertisementId))
                .ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId))
                .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.Media))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<TutorAdvertisement, RequestTutorAdvertisement>()
                .ForMember(dest => dest.AdvertisementId, opt => opt.MapFrom(src => src.AdvertisementId))
                .ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId))
                .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.Media))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.OnlineTutor, opt => opt.MapFrom(src => src.Tutor.OnlineTutor))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Tutor.Photo))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Tutor.User.Location.CityOrProvince))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Tutor.User.Location))
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Tutor.Faculty))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Tutor.User.UserName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Tutor.Title));
        }
    }
}
