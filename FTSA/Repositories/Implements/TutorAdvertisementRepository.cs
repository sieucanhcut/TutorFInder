using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Implements
{
    public class TutorAdvertisementRepository : RepositoryBase<TutorAdvertisement>, ITutorAdvertisementRepository
    {
        private readonly TutorWebContext _webContext;
        public TutorAdvertisementRepository(TutorWebContext dataContext) : base(dataContext)
        {
            _webContext = dataContext;
        }

        public async Task CreateAsync(TutorAdvertisement entity)
        {
            using var transaction = await _webContext.Database.BeginTransactionAsync();
            try
            {
                var newTutorAdvertisement = new TutorAdvertisement
                {
                    AdvertisementId = entity.AdvertisementId,
                    Media = entity.Media,
                    TutorId = entity.TutorId,
                    UpdateDate = DateTime.UtcNow,
                    Description = entity.Description
                };

                await _webContext.TutorAdvertisements.AddAsync(newTutorAdvertisement);
                await _webContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            var adToDelete = await _webContext.TutorAdvertisements.FirstOrDefaultAsync(t => t.AdvertisementId == id);

            if (adToDelete == null)
            {
                return false;
            }

            _webContext.TutorAdvertisements.Remove(adToDelete);
            return await _webContext.SaveChangesAsync() > 0;
        }

        public async Task<IQueryable<TutorAdvertisement>> FindAllAsync(bool trackChanges)
        {
            if (trackChanges)
            {
                return await Task.FromResult(_webContext.TutorAdvertisements
                    .Include(t => t.Tutor)
                    .ThenInclude(t => t.User)
                    .ThenInclude(u => u.Location)
                    .AsQueryable());
            }
            else
            {
                return await Task.FromResult(_webContext.TutorAdvertisements
                    .Include(t => t.Tutor)
                    .ThenInclude(t => t.User)
                    .ThenInclude(u => u.Location)
                    .AsNoTracking()
                    .AsQueryable());
            }
        }

        public async Task<IQueryable<TutorAdvertisement>> FindByConditionAsync(Expression<Func<TutorAdvertisement, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return await Task.FromResult(_webContext.TutorAdvertisements
                    .Include(t => t.Tutor)
                    .ThenInclude(t => t.User)
                    .ThenInclude(u => u.Location)
                    .Where(expression)
                    .AsQueryable());
            }
            else
            {
                return await Task.FromResult(_webContext.TutorAdvertisements
                    .Include(t => t.Tutor)
                    .ThenInclude(t => t.User)
                    .ThenInclude(u => u.Location)
                    .Where(expression)
                    .AsNoTracking()
                    .AsQueryable());
            }
        }

        public async Task<TutorAdvertisement?> FindByIdAsync(Guid id)
        {
            return await _webContext.TutorAdvertisements
                .Include(ad => ad.Tutor)
                .ThenInclude(t => t.User)
                .ThenInclude(u => u.Location)
                .Where(t => t.AdvertisementId == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> UpdateAsync(TutorAdvertisement entity, Guid id)
        {
            var advertisementToUpdate = await _webContext.TutorAdvertisements.FindAsync(id);

            if (advertisementToUpdate == null)
            {
                return false;
            }

            advertisementToUpdate.UpdateDate = DateTime.UtcNow;
            advertisementToUpdate.Description = entity.Description;
            advertisementToUpdate.Media = entity.Media;

            _webContext.TutorAdvertisements.Update(advertisementToUpdate);
            return await _webContext.SaveChangesAsync() > 0;
        }
    }
}
