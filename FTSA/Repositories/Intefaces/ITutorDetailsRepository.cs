using Entities;
using Entities.Dto;
using Repositories.Intefaces;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface ITutorDetailsRepository : IRepositoryBase<RequestTutorDetails>
    {
        public Task<IQueryable<RequestTutorDetails>> FindAllAsync(bool trackChanges);
        public Task<IQueryable<RequestTutorDetails>> FindByConditionAsync(Expression<Func<RequestTutorDetails, bool>> expression, bool trackChanges);
        public Task CreateAsync(TutorDetails entity);
        public Task<bool?> UpdateAsync(RequestTutorDetails entity, Guid id);
        public Task<bool?> DeleteAsync(Guid id);
        public Task<RequestTutorDetails?> FindByIdAsync(Guid id);
    }
}
