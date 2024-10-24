using AutoMapper;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class TutorDetailsProfile : Profile
    {
        public TutorDetailsProfile()
        {
            CreateMap<RequestTutorDetails, TutorDetails>()
                .ForMember(dest => dest.AcademicSpecialty, opt => opt.MapFrom(src => src.AcademicSpecialty))
                .ForMember(dest => dest.TeachingAchievement, opt => opt.MapFrom(src => src.TeachingAchievement))
                .ForMember(dest => dest.SelfIntroduction, opt => opt.MapFrom(src => src.SelfIntroduction))
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Faculty))
                .ForMember(dest => dest.OnlineTutor, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId))
                .ForMember(dest => dest.IncludingPhotos, opt => opt.MapFrom(src => src.IncludingPhotos))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Transportation, opt => opt.MapFrom(src => src.Transportation))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<TutorDetails, RequestTutorDetails>()
                .ForMember(dest => dest.Transportation, opt => opt.MapFrom(src => src.Transportation))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId))
                .ForMember(dest => dest.OnlineTutor, opt => opt.MapFrom(src => src.OnlineTutor))
                .ForMember(dest => dest.TeachingAchievement, opt => opt.MapFrom(src => src.TeachingAchievement))
                .ForMember(dest => dest.AcademicSpecialty, opt => opt.MapFrom(src => src.AcademicSpecialty))
                .ForMember(dest => dest.SelfIntroduction, opt => opt.MapFrom(src => src.SelfIntroduction))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.Location.CityOrProvince))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.User.Location.District))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.IncludingPhotos, opt => opt.MapFrom(src => src.IncludingPhotos))
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Faculty))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender))
                .ForMember(dest => dest.PlaceOfWork, opt => opt.MapFrom(src => src.User.PlaceOfWork))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.User.UpdateDate))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
        }
    }
}
