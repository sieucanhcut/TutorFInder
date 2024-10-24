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

        public async Task CreateAsync(RequestTutorAdvertisement entity)
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

        public async Task<IQueryable<RequestTutorAdvertisement>> FindAllAsync(bool trackChanges)
        {
            return await Task.FromResult(
                trackChanges
                ? _webContext.TutorAdvertisements
                .Include(ad => ad.Tutor)
                .ThenInclude(t => t.User)
                .ThenInclude(u => u.Location)
                .Select(advertisement => new RequestTutorAdvertisement
                {
                    AdvertisementId = advertisement.AdvertisementId,
                    City = advertisement.Tutor.User.Location.CityOrProvince,
                    Description = advertisement.Description,
                    District = advertisement.Tutor.User.Location.District,
                    UserName = advertisement.Tutor.User.UserName,
                    Faculty = advertisement.Tutor.Faculty,
                    Media = advertisement.Media,
                    OnlineTutor = advertisement.Tutor.OnlineTutor,
                    Photo = advertisement.Tutor.Photo,
                    Title = advertisement.Tutor.Title,
                    TutorId = advertisement.TutorId
                })
            : _webContext.TutorAdvertisements
                .Include(ad => ad.Tutor)
                .ThenInclude(t => t.User)
                .ThenInclude(u => u.Location)
                .AsNoTracking()
                .Select(advertisement => new RequestTutorAdvertisement
                {
                    AdvertisementId = advertisement.AdvertisementId,
                    City = advertisement.Tutor.User.Location.CityOrProvince,
                    Description = advertisement.Description,
                    District = advertisement.Tutor.User.Location.District,
                    UserName = advertisement.Tutor.User.UserName,
                    Faculty = advertisement.Tutor.Faculty,
                    Media = advertisement.Media,
                    OnlineTutor = advertisement.Tutor.OnlineTutor,
                    Photo = advertisement.Tutor.Photo,
                    Title = advertisement.Tutor.Title,
                    TutorId = advertisement.TutorId
                })
    );
        }

        public async Task<IQueryable<RequestTutorAdvertisement>> FindByConditionAsync(Expression<Func<RequestTutorAdvertisement, bool>> expression, bool trackChanges)
        {
            var query = _webContext.TutorAdvertisements
                .Include(ad => ad.Tutor)
                .ThenInclude(t => t.User)
                .ThenInclude(u => u.Location)
                .Select(advertisement => new RequestTutorAdvertisement 
                { 
                    AdvertisementId = advertisement.AdvertisementId,
                    City = advertisement.Tutor.User.Location.CityOrProvince,
                    Description = advertisement.Description,
                    District = advertisement.Tutor.User.Location.District,
                    UserName = advertisement.Tutor.User.UserName,
                    Faculty = advertisement.Tutor.Faculty,
                    Media = advertisement.Media,
                    OnlineTutor = advertisement.Tutor.OnlineTutor,
                    Photo = advertisement.Tutor.Photo,
                    Title = advertisement.Tutor.Title,
                    TutorId = advertisement.TutorId
                });

            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }
            var filteredQuery = query.Where(expression);

            return await Task.FromResult(filteredQuery);
        }

        public async Task<RequestTutorAdvertisement?> FindByIdAsync(Guid id)
        {
            return await _webContext.TutorAdvertisements
                .Include(ad => ad.Tutor)
                .ThenInclude(t => t.User)
                .ThenInclude(u => u.Location)
                .Select(advertisement => new RequestTutorAdvertisement
                {
                    AdvertisementId = advertisement.AdvertisementId,
                    City = advertisement.Tutor.User.Location.CityOrProvince,
                    Description = advertisement.Description,
                    District = advertisement.Tutor.User.Location.District,
                    UserName = advertisement.Tutor.User.UserName,
                    Faculty = advertisement.Tutor.Faculty,
                    Media = advertisement.Media,
                    OnlineTutor = advertisement.Tutor.OnlineTutor,
                    Photo = advertisement.Tutor.Photo,
                    Title = advertisement.Tutor.Title,
                    TutorId = advertisement.TutorId
                }).Where(t => t.AdvertisementId == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> UpdateAsync(RequestTutorAdvertisement entity, Guid id)
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
