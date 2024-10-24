using Entities;
using Entities.Dto;
using Repositories.Intefaces;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface ITutorAdvertisementRepository : IRepositoryBase<TutorAdvertisement>
    {
        public Task<IQueryable<TutorAdvertisement>> FindAllAsync(bool trackChanges);
        public Task<IQueryable<TutorAdvertisement>> FindByConditionAsync(Expression<Func<TutorAdvertisement, bool>> expression, bool trackChanges);
        public Task CreateAsync(TutorAdvertisement entity);
        public Task<bool?> UpdateAsync(TutorAdvertisement entity, Guid id);
        public Task<bool?> DeleteAsync(Guid id);
        public Task<TutorAdvertisement?> FindByIdAsync(Guid id);
    }
}