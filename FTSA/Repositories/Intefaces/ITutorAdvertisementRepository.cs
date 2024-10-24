using Entities;
using Entities.Dto;
using Repositories.Intefaces;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface ITutorAdvertisementRepository : IRepositoryBase<TutorAdvertisement>
    {
        public Task<IQueryable<RequestTutorAdvertisement>> FindAllAsync(bool trackChanges);
        public Task<IQueryable<RequestTutorAdvertisement>> FindByConditionAsync(Expression<Func<RequestTutorAdvertisement, bool>> expression, bool trackChanges);
        public Task CreateAsync(RequestTutorAdvertisement entity);
        public Task<bool?> UpdateAsync(RequestTutorAdvertisement entity, Guid id);
        public Task<bool?> DeleteAsync(Guid id);
        public Task<RequestTutorAdvertisement?> FindByIdAsync(Guid id);
    }
}
