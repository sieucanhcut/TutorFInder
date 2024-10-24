using AutoMapper;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class TutorDetailsService : ITutorDetailsService
    {
        private readonly ITutorDetailsRepository _tutorDetailsRepository;
        private readonly IMapper _mapper;
        public TutorDetailsService(ITutorDetailsRepository repos, IMapper mapper)
        {
            _mapper = mapper;
            _tutorDetailsRepository = repos;
        }
        public async Task<IEnumerable<RequestTutorDetails>?> FindAllAsync(bool trackChanges)
        {
            var tutors = await _tutorDetailsRepository.FindAllAsync(trackChanges);
            return tutors?.AsEnumerable().Select(t => new RequestTutorDetails
            {
                UserId = t.UserId,
                TutorId = t.TutorId,
                Title = t.Title,
                Faculty = t.Faculty,
                Transportation = t.Transportation,
                OnlineTutor = t.OnlineTutor,
                SelfIntroduction = t.SelfIntroduction,
                TeachingAchievement = t.TeachingAchievement,
                AcademicSpecialty = t.AcademicSpecialty,
                Photo = t.Photo,
                IncludingPhotos = t.IncludingPhotos,
                UserName = t.User?.UserName,
                DateOfBirth = t.User?.DateOfBirth,
                PlaceOfWork = t.User?.PlaceOfWork,
                City = t.User?.Location?.CityOrProvince,
                District = t.User?.Location?.District,
                Gender = t.User?.Gender,
                UpdateDate = t.User?.UpdateDate
            }).ToList();
        }

        public async Task<RequestTutorDetails?> FindByIdAsync(Guid id)
        {
            var tutor = await _tutorDetailsRepository.FindByIdAsync(id);
            return tutor != null ? MapToDto(tutor) : null;
        }

        public async Task CreateAsync(RequestTutorDetails request)
        {
            var tutorDetails = new TutorDetails
            {
                TutorId = request.TutorId,
                UserId = request.UserId,
                Title = request.Title,
                Faculty = request.Faculty,
                Transportation = request.Transportation,
                OnlineTutor = request.OnlineTutor,
                SelfIntroduction = request.SelfIntroduction,
                TeachingAchievement = request.TeachingAchievement,
                AcademicSpecialty = request.AcademicSpecialty,
                Photo = request.Photo,
                IncludingPhotos = request.IncludingPhotos
            };
            await _tutorDetailsRepository.CreateAsync(tutorDetails);

        }

        public async Task<bool?> UpdateAsync(RequestTutorDetails request, Guid id)
        {
            var tutorEntity = await _tutorDetailsRepository.FindByIdAsync(id);
            if (tutorEntity == null) return false;

            tutorEntity = UpdateEntityFromDto(tutorEntity, request);
            return await _tutorDetailsRepository.UpdateAsync(tutorEntity, id);
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            return await _tutorDetailsRepository.DeleteAsync(id);
        }

        public async Task<List<RequestTutorDetails>?> SearchTutorsAsync(Expression<Func<RequestTutorDetails, bool>> expression, bool trackChanges)
        {
            var tutors = await _tutorDetailsRepository.FindByConditionAsync(MapExpressionToEntity(expression), trackChanges);
            return tutors?.AsEnumerable().Select(t => new RequestTutorDetails
            {
                UserId = t.UserId,
                TutorId = t.TutorId,
                Title = t.Title,
                Faculty = t.Faculty,
                Transportation = t.Transportation,
                OnlineTutor = t.OnlineTutor,
                SelfIntroduction = t.SelfIntroduction,
                TeachingAchievement = t.TeachingAchievement,
                AcademicSpecialty = t.AcademicSpecialty,
                Photo = t.Photo,
                IncludingPhotos = t.IncludingPhotos,
                UserName = t.User?.UserName,
                DateOfBirth = t.User?.DateOfBirth,
                PlaceOfWork = t.User?.PlaceOfWork,
                City = t.User?.Location?.CityOrProvince,
                District = t.User?.Location?.District,
                Gender = t.User?.Gender,
                UpdateDate = t.User?.UpdateDate
            }).ToList();
        }

        private RequestTutorDetails MapToDto(TutorDetails tutor)
        {
            return new RequestTutorDetails
            {
                UserId = tutor.UserId,
                TutorId = tutor.TutorId,
                Title = tutor.Title,
                Faculty = tutor.Faculty,
                Transportation = tutor.Transportation,
                OnlineTutor = tutor.OnlineTutor,
                SelfIntroduction = tutor.SelfIntroduction,
                TeachingAchievement = tutor.TeachingAchievement,
                AcademicSpecialty = tutor.AcademicSpecialty,
                Photo = tutor.Photo,
                IncludingPhotos = tutor.IncludingPhotos,
                UserName = tutor.User?.UserName,
                DateOfBirth = tutor.User?.DateOfBirth,
                PlaceOfWork = tutor.User?.PlaceOfWork,
                City = tutor.User?.Location?.CityOrProvince,
                District = tutor.User?.Location?.District,
                Gender = tutor.User?.Gender,
                UpdateDate = tutor.User?.UpdateDate
            };
        }

        private TutorDetails UpdateEntityFromDto(TutorDetails entity, RequestTutorDetails dto)
        {
            entity.Title = dto.Title;
            entity.Faculty = dto.Faculty;
            entity.Transportation = dto.Transportation;
            entity.OnlineTutor = dto.OnlineTutor;
            entity.SelfIntroduction = dto.SelfIntroduction;
            entity.TeachingAchievement = dto.TeachingAchievement;
            entity.AcademicSpecialty = dto.AcademicSpecialty;
            entity.Photo = dto.Photo;
            entity.IncludingPhotos = dto.IncludingPhotos;
            entity.UserId = dto.UserId;
            return entity;
        }

        private Expression<Func<TutorDetails, bool>> MapExpressionToEntity(Expression<Func<RequestTutorDetails, bool>> expression)
        {
            var mappedExpression = _mapper.Map<Expression<Func<TutorDetails, bool>>>(expression);
            return mappedExpression;
        }
    }
}
