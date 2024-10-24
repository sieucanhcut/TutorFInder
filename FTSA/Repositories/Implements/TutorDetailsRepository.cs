using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Repositories.Intefaces;
using Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Implements
{
    public class TutorDetailsRepository : RepositoryBase<TutorDetails>, ITutorDetailsRepository
    {
        private readonly TutorWebContext _webContext;
        public TutorDetailsRepository(TutorWebContext webContext) : base(webContext)
        {
            _webContext = webContext;
        }

        public void Create(RequestTutorDetails entity)
        {
            throw new NotImplementedException();
        }

        async Task<bool?> ITutorDetailsRepository.DeleteAsync(Guid id)
        {
            var tutordetails = await _webContext.Tutors.FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutordetails == null)
            {
                return false;
            }

            _webContext.Tutors.Remove(tutordetails);
            return await _webContext.SaveChangesAsync() > 0;
        }

        public void Delete(RequestTutorDetails entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TutorDetails>> FindByConditionAsync(Expression<Func<TutorDetails, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return await Task.FromResult(_webContext.Tutors
                    .Include(t => t.User)
                    .ThenInclude(u => u.Location)
                    .Where(expression)
                    .AsQueryable());
            }
            else
            {
                return await Task.FromResult(_webContext.Tutors
                    .Include(t => t.User)
                    .ThenInclude(u => u.Location)
                    .Where(expression)
                    .AsNoTracking()
                    .AsQueryable());
            }
        }

        public async Task<bool?> UpdateAsync(TutorDetails entity, Guid id)
        {
            var tutorDetailsUpdate = await _webContext.Tutors.FindAsync(id);

            if (tutorDetailsUpdate == null)
            {
                return false;
            }
            tutorDetailsUpdate.AcademicSpecialty = entity.AcademicSpecialty;
            tutorDetailsUpdate.Faculty = entity.Faculty;
            tutorDetailsUpdate.OnlineTutor = entity.OnlineTutor;
            tutorDetailsUpdate.SelfIntroduction = entity.SelfIntroduction;
            tutorDetailsUpdate.TeachingAchievement = entity.TeachingAchievement;
            tutorDetailsUpdate.Title = entity.Title;
            tutorDetailsUpdate.TutorId = entity.TutorId;
            tutorDetailsUpdate.Transportation = entity.Transportation;
            tutorDetailsUpdate.Photo = entity.Photo;
            tutorDetailsUpdate.IncludingPhotos = entity.IncludingPhotos;

            _context.Tutors.Update(tutorDetailsUpdate);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task ITutorDetailsRepository.CreateAsync(TutorDetails entity)
        {
            using var transaction = await _webContext.Database.BeginTransactionAsync();
            try
            {
                var newTutorDetails = new TutorDetails
                {
                    UserId = entity.UserId,
                    AcademicSpecialty = entity.AcademicSpecialty,
                    Faculty = entity.Faculty,
                    OnlineTutor = entity.OnlineTutor,
                    SelfIntroduction = entity.SelfIntroduction,
                    TeachingAchievement = entity.TeachingAchievement,
                    Title = entity.Title,
                    TutorId = entity.TutorId,
                    Transportation = entity.Transportation,
                    Photo = entity.Photo,
                    IncludingPhotos = entity.IncludingPhotos
                };

                await _webContext.Tutors.AddAsync(newTutorDetails);
                await _webContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        async Task<IQueryable<TutorDetails>> ITutorDetailsRepository.FindAllAsync(bool trackChanges)
        {
            if (trackChanges)
            {
                return await Task.FromResult(_webContext.Tutors
                    .Include(t => t.User)
                    .ThenInclude(u => u.Location)
                    .AsQueryable());
            }
            else
            {
                return await Task.FromResult(_webContext.Tutors
                    .Include(t => t.User)
                    .ThenInclude(u => u.Location)
                    .AsNoTracking()
                    .AsQueryable());
            }
        }

        IQueryable<TutorDetails> IRepositoryBase<TutorDetails>.FindAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TutorDetails> FindByCondition(Expression<Func<TutorDetails, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        async Task<TutorDetails?> ITutorDetailsRepository.FindByIdAsync(Guid id)
        {
            return await _webContext.Tutors
                .Include(t => t.User)
                .ThenInclude(u => u.Location)
                .Where(t => t.TutorId == id).FirstOrDefaultAsync();
        }

        public Task<IQueryable<TutorDetails>> FindAllAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<TutorDetails?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}