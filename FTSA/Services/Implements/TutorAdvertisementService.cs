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
        private readonly ITutorAdvertisementRepository _repository;
        public TutorAdvertisementService(ITutorAdvertisementRepository repository) 
        {
            _repository = repository;
        }
        public async Task CreateAsync(RequestTutorAdvertisement request)
        {
            await _repository.CreateAsync(request);
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RequestTutorAdvertisement>?> FindAllAsync(bool trackchanges)
        {
            return await _repository.FindAllAsync(trackchanges);
        }

        public async Task<RequestTutorAdvertisement?> FindByIdAsync(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<List<RequestTutorAdvertisement>?> SearchTutorsAsync(Expression<Func<RequestTutorAdvertisement, bool>> expression, bool trackChanges)
        {
            var queryableTutors = await _repository.FindByConditionAsync(expression, trackChanges);
            return await queryableTutors.ToListAsync();
        }

        public async Task<bool?> UpdateAsync(RequestTutorAdvertisement request, Guid id)
        {
            return await _repository.UpdateAsync(request, id);
        }
    }
}
