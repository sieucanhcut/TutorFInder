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
        public TutorDetailsService(ITutorDetailsRepository repos)
        {
            _tutorDetailsRepository = repos;
        }
        public async Task CreateAsync(TutorDetails request)
        {
           await _tutorDetailsRepository.CreateAsync(request);
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            return await _tutorDetailsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RequestTutorDetails>?> FindAllAsync(bool trackchanges)
        {
            return await _tutorDetailsRepository.FindAllAsync(trackchanges);
        }

        public async Task<RequestTutorDetails?> FindByIdAsync(Guid id)
        {
            return await _tutorDetailsRepository.FindByIdAsync(id);
        }

        public async Task<bool?> UpdateAsync(RequestTutorDetails request, Guid id)
        {
            return await _tutorDetailsRepository.UpdateAsync(request, id);
        }
        public async Task<List<RequestTutorDetails>?> SearchTutorsAsync(Expression<Func<RequestTutorDetails, bool>> expression, bool trackChanges)
        {
            var queryableTutors = await _tutorDetailsRepository.FindByConditionAsync(expression, trackChanges);
            return await queryableTutors.ToListAsync();
        }
    }
}
