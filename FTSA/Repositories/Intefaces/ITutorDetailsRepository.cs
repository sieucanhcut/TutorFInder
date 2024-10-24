using Entities;
using Entities.Dto;
using Repositories.Intefaces;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface ITutorDetailsRepository : IRepositoryBase<TutorDetails>
    {
        public Task<IQueryable<TutorDetails>> FindAllAsync(bool trackChanges);
        public Task<IQueryable<TutorDetails>> FindByConditionAsync(Expression<Func<TutorDetails, bool>> expression, bool trackChanges);
        public Task CreateAsync(TutorDetails entity);
        public Task<bool?> UpdateAsync(TutorDetails entity, Guid id);
        public Task<bool?> DeleteAsync(Guid id);
        public Task<TutorDetails?> FindByIdAsync(Guid id);
    }
}
