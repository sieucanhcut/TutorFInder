using AutoMapper;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Repositories.Implements;
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
    public class TutorAdvertisementService : ITutorAdvertisementService
    {
        private readonly ITutorAdvertisementRepository _repos;
        private readonly IMapper _mapper;
        public TutorAdvertisementService(ITutorAdvertisementRepository repos, IMapper mapper)
        {
            _mapper = mapper;
            _repos = repos;
        }
        private RequestTutorAdvertisement MapToDto(TutorAdvertisement tutorAdvertisement)
        {
            return new RequestTutorAdvertisement
            {
                City = tutorAdvertisement.Tutor?.User?.Location?.CityOrProvince,
                District = tutorAdvertisement.Tutor?.User?.Location?.District,
                Faculty = tutorAdvertisement.Tutor?.Faculty,
                AdvertisementId = tutorAdvertisement.AdvertisementId,
                Description = tutorAdvertisement.Description,
                Media = tutorAdvertisement.Media,
                OnlineTutor = tutorAdvertisement.Tutor?.OnlineTutor,
                Photo = tutorAdvertisement.Tutor?.Photo,
                Title = tutorAdvertisement.Tutor?.Title,
                TutorId = tutorAdvertisement.TutorId,
                UserName = tutorAdvertisement.Tutor?.User?.UserName,
            };
        }

        private TutorAdvertisement UpdateEntityFromDto(TutorAdvertisement entity, RequestTutorAdvertisement dto)
        {
            entity.AdvertisementId = dto.AdvertisementId;
            entity.TutorId = dto.TutorId;
            entity.Description = dto.Description;
            entity.Media = dto.Media;
            return entity;
        }

        private Expression<Func<TutorAdvertisement, bool>> MapExpressionToEntity(Expression<Func<RequestTutorAdvertisement, bool>> expression)
        {
            var mappedExpression = _mapper.Map<Expression<Func<TutorAdvertisement, bool>>>(expression);
            return mappedExpression;
        }

        public async Task<IEnumerable<RequestTutorAdvertisement>?> FindAllAsync(bool trackchanges)
        {
            var advertisements = await _repos.FindAllAsync(trackchanges);
            return advertisements?.AsEnumerable().Select(t => new RequestTutorAdvertisement
            {
                City = t.Tutor?.User?.Location?.CityOrProvince,
                District = t.Tutor?.User?.Location?.District,
                Faculty = t.Tutor?.Faculty,
                AdvertisementId = t.AdvertisementId,
                Description = t.Description,
                Media = t.Media,
                OnlineTutor = t.Tutor?.OnlineTutor,
                Photo = t.Tutor?.Photo,
                Title = t.Tutor?.Title,
                TutorId = t.TutorId,
                UserName = t.Tutor?.User?.UserName,
            }).ToList();
        }

        public async Task<RequestTutorAdvertisement?> FindByIdAsync(Guid id)
        {
            var advertisement = await _repos.FindByIdAsync(id);
            return advertisement != null ? MapToDto(advertisement) : null;
        }

        public async Task CreateAsync(RequestTutorAdvertisement request)
        {
            var tutorAdvetisement = new TutorAdvertisement
            {
                AdvertisementId = request.AdvertisementId,
                Description = request.Description,
                Media = request.Media,
                TutorId = request.TutorId,
                UpdateDate = DateTime.UtcNow,
            };
            await _repos.CreateAsync(tutorAdvetisement);
        }

        public async Task<bool?> UpdateAsync(RequestTutorAdvertisement request, Guid id)
        {
            var adEntity = await _repos.FindByIdAsync(id);
            if (adEntity == null) return false;

            adEntity = UpdateEntityFromDto(adEntity, request);
            return await _repos.UpdateAsync(adEntity, id);
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            return await _repos.DeleteAsync(id);
        }

        public async Task<List<RequestTutorAdvertisement>?> SearchTutorsAsync(Expression<Func<RequestTutorAdvertisement, bool>> expression, bool trackChanges)
        {
            var advertisements = await _repos.FindByConditionAsync(MapExpressionToEntity(expression), trackChanges);
            return advertisements?.AsEnumerable().Select(t => new RequestTutorAdvertisement
            {
                City = t.Tutor?.User?.Location?.CityOrProvince,
                District = t.Tutor?.User?.Location?.District,
                Faculty = t.Tutor?.Faculty,
                AdvertisementId = t.AdvertisementId,
                Description = t.Description,
                Media = t.Media,
                OnlineTutor = t.Tutor?.OnlineTutor,
                Photo = t.Tutor?.Photo,
                Title = t.Tutor?.Title,
                TutorId = t.TutorId,
                UserName = t.Tutor?.User?.UserName
            }).ToList();
        }
    }
}